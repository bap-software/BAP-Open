using BAP.Common;
using BAP.FileSystem;
using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BAP.Web.Areas.Administration.Models
{
    public class BAPFolder
    {
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_BAPFolder_Name")]
        public string Name { get; set; }
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_BAPFolder_Description")]
        public string Description { get; set; }
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_BAPFolder_FullRelativePath")]
        public string FullRelativePath { get; set; }
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_BAPFolder_ParentFolder")]
        public BAPFolder ParentFolder { get; set; }
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_BAPFolder_ChildFolders")]
        public List<BAPFolder> ChildFolders { get; set; }
        public bool IsCurrent { get; set; }
    }

    public class BAPFile
    {
        public BAPFileInfo FileInfo { get; set; }

        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_BAPFile_Name")]
        [SortingField(true, true, true, false)]
        public string Name { get; set; }

        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_BAPFile_Description")]
        public string Description { get; set; }

        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_BAPFile_Type")]
        [SortingField]
        public string Type { get; set; }

        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_BAPFile_MimeType")]
        public string MimeType { get; set; }

        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_BAPFile_LastModified")]
        [SortingField]
        public DateTime LastModified { get; set; }

        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_BAPFile_Size")]
        [SortingField]
        public long Size { get; set; }

        public string PathUrl { get; set; }

        public bool TextEditAllowed { get; set; }
    }

    public class BAPFileSystemData : IPagedList
    {
        private BAPFolder _currentFolder = null;
        public BAPFileSystemData(BAPFolder rootFolder, BAPFolder currentFolder, int pageNumber, int pageSize, string filesFilter, string filesSortOrder, List<BAPFile> folderFiles)
        {
            RootFolder = rootFolder;
            CurrentFolder = currentFolder;
            PageNumber = pageNumber;
            PageSize = pageSize;
            CurrentFileFilter = filesFilter;
            CurrentFileSort = filesSortOrder;
            CurrentFolderFiles = folderFiles;
            ProcessData();
        }

        #region public properties
        
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_BAPFileSystemFolder_RootFolders")]
        public BAPFolder RootFolder { get; private set; }        
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_BAPFileSystemFolder_CurrentFileSort")]
        public string CurrentFileSort { get; private set; }
        public Dictionary<string, string> SortData { get; set; }
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_BAPFileSystemFolder_CurrentFileFilter")]
        public string CurrentFileFilter { get; private set; }
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_BAPFileSystemFolder_CurrentFolder")]
        public BAPFolder CurrentFolder
        {
            get
            {
                if(_currentFolder != null)
                    return _currentFolder;
                return RootFolder;
            }
            private set
            {
                _currentFolder = value;                
            }           
        }
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_BAPFileSystemFolder_CurrentFolderFiles")]
        public List<BAPFile> CurrentFolderFiles { get; private set; }

        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_BAPFileSystemFolder_PageNumber")]
        public int PageNumber
        {
            get; private set;
        }

        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_BAPFileSystemFolder_FilesPerPage")]
        public int PageSize
        {
            get; private set;
        }

        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_BAPFileSystemFolder_PageCount")]
        public int PageCount
        {
            get; private set;
        }

        public int TotalItemCount
        {
            get; private set;
        }
       
        public bool HasPreviousPage
        {
            get; private set;
        }

        public bool HasNextPage
        {
            get; private set;
        }

        public bool IsFirstPage
        {
            get; private set;
        }

        public bool IsLastPage
        {
            get; private set;
        }

        public int FirstItemOnPage
        {
            get; private set;
        }

        public int LastItemOnPage
        {
            get; private set;
        }

        #endregion

        #region private methods
        private void ProcessData()
        {
            // init sorting data            
            SortData = new Dictionary<string, string>();
            var direction = "asc";
            var field = "";
            if (!string.IsNullOrEmpty(CurrentFileSort) && CurrentFileSort.Contains("-"))
            {
                var arr = CurrentFileSort.Split("-".ToCharArray());
                field = arr[0];
                direction = arr[1];
            }

            var properties = typeof(BAPFile).GetProperties().Where(prop => prop.IsDefined(typeof(SortingFieldAttribute), false));
            foreach (var property in properties)
            {
                SortingFieldAttribute sortAttr = (SortingFieldAttribute)Attribute.GetCustomAttribute(property, typeof(SortingFieldAttribute));
                if (sortAttr != null)
                {
                    if (sortAttr.AllowAscending && sortAttr.AllowDescending)
                        SortData.Add(property.Name, (field == property.Name && direction == "asc") ? "desc" : "asc");
                    else if (sortAttr.AllowAscending)
                        SortData.Add(property.Name, "asc");
                    else if (sortAttr.AllowDescending)
                        SortData.Add(property.Name, "desc");

                    if(string.IsNullOrEmpty(CurrentFileSort) && sortAttr.IsDefault)
                    {
                        CurrentFileSort = property.Name;
                        if (sortAttr.IsDefaultDesc)
                            CurrentFileSort += "-desc";
                        else
                            CurrentFileSort += "-asc";
                    }
                }
            }

            // init paging data
            if (CurrentFolderFiles != null && CurrentFolderFiles.Count > 0)
            {
                CurrentFolderFiles = FilterFiles(CurrentFolderFiles, CurrentFileFilter);
                CurrentFolderFiles = SortFiles(CurrentFolderFiles, CurrentFileSort);
                TotalItemCount = CurrentFolderFiles.Count;
                if (CurrentFolderFiles.Count > PageSize)
                {
                    CurrentFolderFiles = CurrentFolderFiles.Skip(PageSize * (PageNumber - 1)).Take(PageSize).ToList();
                    FirstItemOnPage = PageSize * (PageNumber - 1);
                    HasNextPage = PageSize * PageNumber < TotalItemCount;
                    HasPreviousPage = PageNumber > 1;
                    IsFirstPage = PageNumber == 1;
                    IsLastPage = !HasNextPage;
                    LastItemOnPage = (IsLastPage) ? TotalItemCount - 1 : (PageSize * PageNumber) - 1;
                    PageCount = (TotalItemCount % PageSize == 0) ? TotalItemCount / PageSize : (TotalItemCount / PageSize) + 1;
                }
                else
                {
                    FirstItemOnPage = 1;
                    HasNextPage = false;
                    HasPreviousPage = false;
                    IsFirstPage = true;
                    IsLastPage = true;
                    LastItemOnPage = TotalItemCount - 1;
                    PageCount = 1;
                }
            }                                                    
        }
                
        private List<BAPFile> FilterFiles(List<BAPFile> files, string filter)
        {
            var result = files;
            if (!string.IsNullOrEmpty(filter))
            {
                result = files.Where(a => a.Name.Contains(filter)).ToList();
            }
            return result;
        }

        private List<BAPFile> SortFiles(List<BAPFile> files, string sortOrder)
        {
            var result = files;
            string[] sortParts = null;
            if (!string.IsNullOrEmpty(sortOrder))
                sortParts = sortOrder.Split("-".ToCharArray());

            if (sortParts != null && sortParts.Length == 2)
            {
                if (sortParts[1].ToLower() == "asc")
                {
                    switch (sortParts[0].ToLower())
                    {
                        case "name": result = files.OrderBy(a => a.Name).ToList(); break;
                        case "type": result = files.OrderBy(a => a.Type).ToList(); break;
                        case "size": result = files.OrderBy(a => a.Size).ToList(); break;
                        case "lastmodified": result = files.OrderBy(a => a.LastModified).ToList(); break;
                    }
                }
                else
                {
                    switch (sortParts[0].ToLower())
                    {
                        case "name": result = files.OrderByDescending(a => a.Name).ToList(); break;
                        case "type": result = files.OrderByDescending(a => a.Type).ToList(); break;
                        case "size": result = files.OrderByDescending(a => a.Size).ToList(); break;
                        case "lastmodified": result = files.OrderByDescending(a => a.LastModified).ToList(); break;
                    }
                }
            }
            return result;
        }

        #endregion
    }
}
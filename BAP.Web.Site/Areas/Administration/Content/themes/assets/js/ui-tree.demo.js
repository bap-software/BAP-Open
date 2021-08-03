/*
Template Name: Color Admin - Responsive Admin Dashboard Template build with Twitter Bootstrap 3.3.7
Version: 2.1.0
Author: Sean Ngu
Website: http://www.seantheme.com/color-admin-v2.1/admin/html/
*/

var handleJstreeCMS = function () {
    $('#jstree-cms').jstree({
        "core": {
            "check_callback": true,
            "themes": {
                "responsive": true
            }
        },
        "contextmenu": {
            "items": function (node) {
                var tmp = $.jstree.defaults.contextmenu.items();
                delete tmp.create.action;   
                delete tmp.remove.action;
                delete tmp.rename.action;   
                delete tmp.ccp;
                tmp.create.label = "New Page";
                tmp.create.action = function (data) {
                    var inst = $.jstree.reference(data.reference),
                        obj = inst.get_node(data.reference);
                    var newNodeId = inst.create_node(obj, "New Page", "last", function (new_node) {
                        setTimeout(function () { inst.edit(new_node); }, 0);
                    });
                    console.log(newNodeId);
                };             

                tmp.rename.action = function (data) {
                    console.log(data);
                    var inst = $.jstree.reference(data.reference),
                        obj = inst.get_node(data.reference);
                    inst.edit(obj);                    
                };

                tmp.remove.action = function (data) {
                    console.log(data);
                    BapConfirm('Are you sure to delete this page?', data.item.label, data, function (thisData) {                        
                        $('#actionType').val('delete');
                        $('#PageActionForm').submit();
                    });                                                             
                };

                return tmp;
            }
        },
        "types": {
            "default": {
                "icon": "fa fa-folder text-warning fa-lg"
            },
            "file": {
                "icon": "fa fa-file text-inverse fa-lg"
            }
        },
        "plugins": ["contextmenu", "types", "wholerow"]
    });

    $('#jstree-cms').on('select_node.jstree', function (e, data) {
        var link = $('#' + data.selected).find('a');
        if (link.attr("href") != "#" && link.attr("href") != "javascript:;" && link.attr("href") != "") {
            if (link.attr("target") === "_blank") {
                link.attr("href").target = "_blank";
            }
            document.location.href = link.attr("href");
            return false;
        }
    });

    $('#jstree-select').on('select_node.jstree', function (e, data) {
        var link = $('#' + data.selected).find('a');
        if (link.attr("href") != "#" && link.attr("href") != "javascript:;" && link.attr("href") != "") {
            if (link.attr("target") === "_blank") {
                link.attr("href").target = "_blank";
            }
            document.location.href = link.attr("href");
            return false;
        }
    });

    $("#jstree-cms").on("create_node.jstree", function (e, data) {
        console.log('Create');
        console.log(data);
        //$("#newPageName").val(data.text);
        //$('#actionType').val('create');        
        //$('#PageActionForm').submit();
    });

    $("#jstree-cms").on("rename_node.jstree", function (e, data) {
        console.log('Rename');
        console.log(data);
        $("#newPageName").val(data.text);
        if (data.old === "New Page") {
            $('#actionType').val('create');
        }
        else {
            $('#actionType').val('rename');
        }
        $('#PageActionForm').submit();
    });
};

var handleJstreeDefault = function() {
    $('#jstree-default').jstree({
        "core": {
            "themes": {
                "responsive": false
            }            
        },
        "types": {
            "default": {
                "icon": "fa fa-folder text-warning fa-lg"
            },
            "file": {
                "icon": "fa fa-file text-inverse fa-lg"
            }
        },
        "plugins": ["types"]
    });

    $('#jstree-default').on('select_node.jstree', function (e, data) {
        var link = $('#' + data.selected).find('a');
        if (link.attr("href") != "#" && link.attr("href") != "javascript:;" && link.attr("href") != "") {
            if (link.attr("target") == "_blank") {
                link.attr("href").target = "_blank";
            }
            document.location.href = link.attr("href");
            return false;
        }
    });
};


var handleJstreeFolder = function () {
    $('#jstree-folder').jstree({
        "core": {
            "themes": {
                "responsive": false
            }
        },
        "types": {
            "default": {
                "icon": "fa fa-folder text-warning fa-lg"
            }
        },
        "plugins": ["types"]
    });    
};


var handleJstreeCheckable = function() {
    $('#jstree-checkable').jstree({
        'plugins': ["wholerow", "checkbox", "types"],
        'core': {
            "themes": {
                "responsive": false
            },    
            'data': [{
                "text": "Same but with checkboxes",
                "children": [{
                    "text": "initially selected",
                    "state": { "selected": true }
                }, {
                    "text": "Folder 1"
                }, {
                    "text": "Folder 2"
                }, {
                    "text": "Folder 3"
                }, {
                    "text": "initially open",
                    "icon": "fa fa-folder fa-lg",
                    "state": {
                        "opened": true
                    },
                    "children": [{
                        "text": "Another node"
                    }, {
                        "text": "disabled node",
                        "state": {
                            "disabled": true
                        }
                    }]
                }, {
                    "text": "custom icon",
                    "icon": "fa fa-cloud-download fa-lg text-inverse"
                }, {
                    "text": "disabled node",
                    "state": {
                        "disabled": true
                    }
                }
            ]},
            "Root node 2"
        ]},
        "types": {
            "default": {
                "icon": "fa fa-folder text-primary fa-lg"
            },
            "file": {
                "icon": "fa fa-file text-success fa-lg"
            }
        }
    });
};


var handleJstreeDragAndDrop = function() {
    $("#jstree-drag-and-drop").jstree({
        "core": {
            "themes": {
                "responsive": false
            }, 
            "check_callback": true,
            'data': [{
                    "text": "Parent Node",
                    "children": [{
                        "text": "Initially selected",
                        "state": {
                            "selected": true
                        }
                    }, {
                        "text": "Folder 1"
                    }, {
                        "text": "Folder 2"
                    }, {
                        "text": "Folder 3"
                    }, {
                        "text": "Initially open",
                        "icon": "fa fa-folder text-success fa-lg",
                        "state": {
                            "opened": true
                        },
                        "children": [
                            {"text": "Disabled node", "disabled": true},
                            {"text": "Another node"}
                        ]
                    }, {
                        "text": "Another Custom Icon",
                        "icon": "fa fa-cog text-inverse fa-lg"
                    }, {
                        "text": "Disabled Node",
                        "state": {
                            "disabled": true
                        }
                    }, {
                        "text": "Sub Nodes",
                        "icon": "fa fa-folder text-danger fa-lg",
                        "children": [
                            {"text": "Item 1", "icon": "fa fa-file fa-lg"},
                            {"text": "Item 2", "icon": "fa fa-file fa-lg"},
                            {"text": "Item 3", "icon": "fa fa-file fa-lg"},
                            {"text": "Item 4", "icon": "fa fa-file fa-lg"},
                            {"text": "Item 5", "icon": "fa fa-file fa-lg"}
                        ]
                    }]
                },
                "Another Node"
            ]
        },
        "types": {
            "default": {
                "icon": "fa fa-folder text-warning fa-lg"
            },
            "file": {
                "icon": "fa fa-file text-warning fa-lg"
            }
        },
        "state": { "key": "demo2" },
        "plugins": [ "contextmenu", "dnd", "state", "types" ]
    });
};


var handleJstreeAjax = function() {
    $('#jstree-ajax').jstree({
        "core": {
            "themes": { "responsive": false },
            "check_callback": true,
            'data': {
                'url': function (node) {
                    return node.id === '#' ? 'assets/plugins/jstree/demo/data_root.json': 'assets/plugins/jstree/demo/' + node.original.file;
                },
                'data': function (node) {
                    return { 'id': node.id };
                },
                "dataType": "json"
            }
        },
        "types": {
            "default": { "icon": "fa fa-folder text-warning fa-lg" },
            "file": { "icon": "fa fa-file text-warning fa-lg" }
        },
        "plugins": [ "dnd", "state", "types" ]
    });
};


var TreeView = function () {
	"use strict";
    return {
        //main function
        init: function () {
            handleJstreeCMS();
            handleJstreeFolder();
            handleJstreeDefault();
            handleJstreeCheckable();
            handleJstreeDragAndDrop();
            handleJstreeAjax();
        }
    };
}();
//Function to hide options in the children dropdowns when parent dropdown value changes
$('.master-drop-down').change(function () {
    var anyFound = false;
    var parentControlId = $(this).attr("id");
    var currentValue = $('select[data-parent-id="' + parentControlId + '"] option:selected').val();
    var parentValue = $('#' + parentControlId + ' option:selected').val();

    $('select[data-parent-id="' + parentControlId + '"] > option').each(function () {        
        var thisParentValue = $(this).attr("data-parent-value");
        $(this).prop('selected', false);
        if (thisParentValue === parentValue || $(this).val() === "" || parentValue === "") {
                $(this).show();
                if ($(this).val() === currentValue && parentValue !== "") {
                    $(this).prop('selected', true);
                }                
                anyFound = true;
            }
            else {
                $(this).hide();
            }
    });

    //No parent - all shown
    if (!anyFound)
    {
        $('select[data-parent-id="' + parentControlId + '"] > option').show();
    }
});

//Initial call for all on the page
$(document).ready(function () {
    $('.master-drop-down').change();
});

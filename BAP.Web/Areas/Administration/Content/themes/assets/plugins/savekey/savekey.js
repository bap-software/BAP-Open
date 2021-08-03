/*
Ctrl+S saving via submit of specified button jQuery plugin
Author: Victor Mamray
Copyright: BAP Sofftware, 2017
*/

(function ($) {
    $.fn.savekey = function (options) {
        if (options != null && options.submit_button_id != null && options.submit_button_id != "")
        {
            $(document).keydown(function (event) {
                var buttonId = "#" + options.submit_button_id;
                // If Control or Command key is pressed and the S key is pressed
                // run save function. 83 is the key code for S.
                if ($(buttonId).is(":visible") && (event.ctrlKey || event.metaKey) && event.which == 83) {                    
                    $(buttonId).trigger("click");
                    event.preventDefault();
                    return false;
                }
            }
            );
        }        
    };
})(jQuery);
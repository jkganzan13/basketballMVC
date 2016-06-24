
$(document).ready(function () {

    $.ajaxSetup({ cache: false });

    window.setTimeout(function () {
        $(".alert").fadeTo(500, 0).slideUp(500, function () {
            $(this).remove();
        });
    }, 5000);
            
    $('body').on('click', '.createDialog', function (e) {
        var url = $(this).attr('href');
        $("#dialog-edit").dialog({
            title: 'Add Player',
            autoOpen: false,
            resizable: false,
            height: 700,
            width: 600,
            show: { effect: 'drop', direction: 'up' },
            modal: true,
            draggable: true,
            open: function (event, ui) {
                $(this).html("Loading...");
                $(this).load(url);
            },
            close: function (event, ui) {
                $(this).dialog("close");
            }
        });
        $("#dialog-edit").dialog("open");
        return false;
    });

    $('body').on('click', '.editDialog', function (e) {
        var url = $(this).attr('href');
        $("#dialog-edit").dialog({
            title: 'Edit Player',
            autoOpen: false,
            resizable: false,
            height: 700,
            width: 600,
            show: { effect: 'drop', direction: 'up' },
            modal: true,
            draggable: true,
            open: function (event, ui) {
                $(this).html("Loading...");
                $(this).load(url);
            },
            close: function (event, ui) {
                $(this).dialog("close");
            }
        });
        $("#dialog-edit").dialog("open");
        return false;
    });

    $('body').on('click', '.deleteDialog', function (e) {
        var url = $(this).attr('href');
        $("#dialog-confirm").dialog({
            title: 'Warning',
            autoOpen: false,
            resizable: false,
            height: 200,
            width: 450,
            show: { effect: 'drop', direction: 'up' },
            modal: true,
            draggable: true,
            buttons: {
                "OK": function () {
                    $(this).dialog("close");
                    window.location = url;
                },
                "Cancel": function () {
                    $(this).dialog("close");
                }
            }
        });
        $("#dialog-confirm").dialog("open");
        return false;
    });

    $('body').on('click', '.viewDialog', function (e) {
        var url = $(this).attr('href');
        $("#dialog-view").dialog({
            title: 'View Player',
            autoOpen: false,
            resizable: false,
            height: 400,
            width: 400,
            show: { effect: 'drop', direction: 'up' },
            modal: true,
            draggable: true,
            open: function (event, ui) {
                $(this).load(url);
            },
            buttons: {
                "Close": function () {
                    $(this).dialog("close");
                    $(this).html("Loading...");
                }
            },
            close: function (event, ui) {
                $(this).dialog("close");
                $(this).html("Loading...");
            }
        });
        $("#dialog-view").dialog("open");
        return false;
    });

});
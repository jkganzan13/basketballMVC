$(document).ready(function () {
    window.setTimeout(function () {
        $(".alert").fadeTo(500, 0).slideUp(500, function () {
            $(this).remove();
        });
    }, 5000);
    $('body').on("click", ".createModal", function (e) {
        e.preventDefault();
        $.ajax({
            type: 'GET',
            url: $(this).attr('href'),
            success: function (data) {
                bootbox.dialog({
                    message: data,
                    title: "Create a " + pageName,
                    buttons: {
                        success: { label: "OK", className: "btn btn-primary", callback: function () { $('#createForm').submit(); } },
                        main: { label: "Cancel", className: "btn btn-default", callback: function () { return true; } }
                    }
                });
            }
        });
    });
    $('body').on("click", ".createSeasonModal", function (e) {
        e.preventDefault();
        $.ajax({
            type: 'GET',
            url: $(this).attr('href'),
            success: function (data) {
                bootbox.dialog({
                    message: data,
                    title: "Create a " + pageName,
                    buttons: {
                        success: { label: "OK", className: "btn btn-primary", callback: function () { $('#createForm').submit(); } },
                        main: { label: "Cancel", className: "btn btn-default", callback: function () { return true; } }
                    }
                });
            }
        });
    });
    $('body').on("click", ".editModal", function (e) {
        e.preventDefault();
        $.ajax({
            type: 'GET',
            url: $(this).attr('href'),
            success: function (data) {
                bootbox.dialog({
                    message: data,
                    title: "Edit a " + pageName,
                    buttons: {
                        success: { label: "OK", className: "btn btn-primary", callback: function () { $('#editForm').submit(); } },
                        main: { label: "Cancel", className: "btn btn-default", callback: function () { return true; } }
                    }
                });
            }
        });
    });
    $('body').on("click", ".deleteModal", function (e) {
        e.preventDefault();
        var url = $(this).attr('href')
        bootbox.confirm({title: 'Delete ' + pageName, message: "Are you sure you want to delete this " + pageName}, function (result) {
            if(result)
                document.location.href = url;
        });
    });
    $('body').on("click", ".detailsModal", function (e) {
        e.preventDefault();
        $.ajax({
            type: 'GET',
            url: $(this).attr('href'),
            success: function (data) {
                bootbox.dialog({
                    message: data,
                    title: pageName + " Details",
                    buttons: {
                        main: { label: "Close", className: "btn btn-default", callback: function () { return true; } }
                    }
                });
            }
        });
    });
    $('body').on("click", ".seasonDetailsModal", function (e) {
        e.preventDefault();
        $.ajax({
            type: 'GET',
            url: $(this).attr('href'),
            success: function (data) {
                bootbox.dialog({
                    message: data,
                    title: pageName + " Details",
                    buttons: {
                        main: { label: "Close", className: "btn btn-default", callback: function () { return true; } }
                    }
                });
            }
        });
    });
});
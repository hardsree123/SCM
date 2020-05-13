var TeamDetailPostBackURL = '/Requirements/Details';
$(document).ready(function () {
    $(".reqDetail").click(function () {
        var $buttonClicked = $(this);
        var id = $buttonClicked.attr('data-id');
        var options = { "backdrop": "static", keyboard: true };
        $.ajax({
            type: "GET",
            url: TeamDetailPostBackURL,
            contentType: "application/json; charset=utf-8",
            data: { "Id": id },
            datatype: "json",
            beforeSend:CommonJs.SetPageLoader(PageLoaderActivity.SHOW)
            ,
            success: function (data) {
                debugger;
                $('#popupcontent').html(data);
                $('#myModal').modal(options);
                $('#myModal').modal('show');
                CommonJs.SetPageLoader(PageLoaderActivity.HIDE);
            },
            error: function () {
                alert("Dynamic content load failed.");
                CommonJs.SetPageLoader(PageLoaderActivity.HIDE);
            }

        });
    });
    $("#closbtn").click(function () {
        $('#myModal').modal('hide');
    });
});



    

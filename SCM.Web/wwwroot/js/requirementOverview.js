
$(document).ready(function () {
    $(".reqDetail").click(function () {
        var TeamDetailPostBackURL = '/Requirements/Details';
        var $buttonClicked = $(this);
        var id = $buttonClicked.attr('data-id');
        var options = { "backdrop": "static", keyboard: true };
        $('#popupcontent').html('');
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
        $('#popupcontent').html('');
        $('#myModal').modal('hide');
    });

    $(".delReq").click(function () {
        var $buttonClicked = $(this);
        var id = $buttonClicked.attr('data-id');
        var options = { "backdrop": "static", keyboard: true };
        $('#popupcontent').html('');
        var TeamDetailPostBackURL = '/Requirements/Delete';
        $.ajax({
            type: "GET",
            url: TeamDetailPostBackURL,
            contentType: "application/json; charset=utf-8",
            data: { "Id": id },
            datatype: "json",
            beforeSend: CommonJs.SetPageLoader(PageLoaderActivity.SHOW)
            ,
            success: function (data) {
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
});



    

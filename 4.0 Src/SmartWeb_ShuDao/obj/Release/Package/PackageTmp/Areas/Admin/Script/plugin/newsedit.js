$(document).ready(function () {
    $("#save").click(function () {
        var obj = [];
        obj = {
            id: $("#id").val(),
            title: $("#newtitle").val(),
            newstype: $("#newsType").val(),
            keywords: $("#keywords").val(),
            description: $("#descripteditor").val(),
            content: $("#contenteditor").html(),
            no_order: $("#no_order").val(),
            imgurl: $("#imgpath").val(),
            videourl: $("#vediourl").val(),
            Date:$("#datepicker").val(),
            access: $("#access").val() == "on" ? 1 : 0,
            top_ok: $("#top_ok").val() == "on" ? 1 : 0
        };
        var str = JSON.stringify(obj);
        $.ajax({
            type: "POST",
            url: "/Admin/News/EditNews",
            datatype: "json",
            data: { models: str },
            success: function (data) {
                if (data == true) {
                  var result= $.Zebra_Dialog('<strong>恭喜！</strong>, 修改成功', {
                        'type': 'information ',
                        'title': '提示',
                        'buttons': [
                    { caption: 'Ok', callback: function () { location.reload(); } },
                        ]
                  });
                } else {
                    $.Zebra_Dialog('<strong>Sorry！</strong>, 修改失败', {
                        'type': 'error ',
                        'title': '异常提示'
                    });
                }
            },
            error: function (mesg) {
                $.Zebra_Dialog('<strong>Sorry！</strong>,  修改失败' + mesg, {
                    'type': 'error ',
                    'title': '异常提示'
                });
            }
        });
    });
});
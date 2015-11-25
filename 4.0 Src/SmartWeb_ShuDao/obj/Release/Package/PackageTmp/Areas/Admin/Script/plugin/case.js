var validator = $("#add").kendoValidator().data("kendoValidator"), status = $(".status");
$(document).ready(function () {
    $("#save").click(function () {
        if (validator.validate()) {
            var obj = [];
            obj = {
                id: $("#id").val(),
                title: $("#title").val(),
                keywords: $("#keywords").val(),
                description: $("#descripteditor").val(),
                content: $("#contenteditor").html(),
                no_order: $("#no_order").val(),
                imgurl: $("#imgpath").val(),
                displayimg: $("#imgpath").val(),
                access: $("#access").val() == "on" ? 1 : 0,
                top_ok: $("#top_ok").val() == "on" ? 1 : 0,
                addtime: $("#addtime").val(),
            };
            var str = JSON.stringify(obj);
            $.ajax({
                type: "POST",
                url: "/Admin/Case/Update",
                datatype: "json",
                data: { models: str },
                success: function (data) {
                    if (data == true) {
                        var result = $.Zebra_Dialog('<strong>恭喜！</strong> 添加成功', {
                            'type': 'information ',
                            'title': '提示',
                            'buttons': [
                        { caption: 'Ok', callback: function () { location.reload(); } },
                            ]
                        });

                    } else {
                        $.Zebra_Dialog('<strong>Sorry！</strong>添加失败', {
                            'type': 'error ',
                            'title': '异常提示'
                        });
                    }
                },
                error: function (mesg) {
                    $.Zebra_Dialog('<strong>Sorry！</strong>执行失败' + mesg, {
                        'type': 'error ',
                        'title': '异常提示'
                    });
                }
            });
        }
    })

});


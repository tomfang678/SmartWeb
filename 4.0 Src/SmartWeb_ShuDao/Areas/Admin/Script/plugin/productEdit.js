 var validator = $("#addnews").kendoValidator().data("kendoValidator"), status = $(".status");
$(document).ready(function () {
    $("#save").click(function () {
        if (validator.validate()) {
            var obj = [];
            obj = {
                id: $("#productid").val(),
                categoryid: $("#productType").val(),
                title: $("#title").val(),
                ctitle: $("#ctitle").val(),
                keywords: $("#keywords").val(),
                description: $("#descript").val(),
                content: $("#contenteditor").html(),
                no_order: $("#no_order").val(),
                access: $("#access").val() == "on" ? 1 : 0,
                top_ok: $("#top_ok").val() == "on" ? 1 : 0,
                imgurl: $("#imgpath").val(),
                displayimg: $("#imgpath").val(),
                imgurls: $("#imgpath").val(),
                discoprice: $("#discoprice").val(),
                price: $("#price").val(),
                discoutprice: $("#discoutprice").val(),
                projectstart: $("#startdate").val(),
                projectend: $("#enddate").val()
            };

            var str = JSON.stringify(obj);
            $.ajax({
                type: "POST",
                url: "/Admin/Product/UpdateProduct",
                datatype: "json",
                data: { models: str },
                success: function (data) {
                    var result = $.Zebra_Dialog('<strong>恭喜！</strong> 操作成功', {
                        'type': 'information ',
                        'title': '提示',
                        'buttons': [
                    { caption: 'Ok', callback: function () { location.reload(); } },
                        ]
                    });
                },
                error: function (mesg) {
                    $.Zebra_Dialog('<strong>Sorry！</strong>,  执行失败', {
                        'type': 'error ',
                        'title': '异常提示'
                    });
                }
            });
        }
    })
});


//实例化编辑器
var umdes = UM.getEditor('contenteditor');
var validator = $("#save").kendoValidator().data("kendoValidator"), status = $(".status");
$(document).ready(function () {
    $("#save").click(function () {
        if (validator.validate()) {
            var jid = $("#cclid").val() == "" ? "0" : $("#cclid").val();
            var timerang = $("#start").val() + "-" + $("#end").val();
            var obj = [];
            obj = {
                id: jid,
                course: $("#course").val(),
                startdate: $("#startdate").val(),
                enddate: $("#enddate").val(),
                classtime: timerang,
                teacher: $("#teacher").val(),
                remark: $("#descripteditor").val(),
                studentnum: $("#studentnum").val(),
                contents: $("#contenteditor").html(),
                address: $("#address").val(),
                daterange: $("#daterange").val(),
                //imgurl: $("#imgurl").val(),
                price: $("#price").val(),
            };
            var str = JSON.stringify(obj);
            var ulr;
            if (jid == "0") {
                ulr = "/Admin/Curriculum/AddCurriculum";
            } else {
                ulr = "/Admin/Curriculum/Update";
            }
            $.ajax({
                type: "POST",
                url: ulr,
                datatype: "json",
                data: { models: str },
                success: function (data, statu) {
                    if (statu == "success") {
                        var t = $.Zebra_Dialog('<strong>恭喜！</strong>, 执行成功', {
                            'type': 'information ',
                            'title': '提示'
                        });
                        location.href = "/Admin/Curriculum";
                    } else {
                        $.Zebra_Dialog('<strong>Sorry！</strong>,  执行失败', {
                            'type': 'error ',
                            'title': '异常提示'
                        });
                    }
                },
                error: function (mesg) {
                    $.Zebra_Dialog(mesg.responseText, {
                        'type': 'error ',
                        'title': '出现异常'
                    });
                }
            });
        }
    })
});
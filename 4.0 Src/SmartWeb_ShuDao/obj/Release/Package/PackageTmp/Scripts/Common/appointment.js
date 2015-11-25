function up() {
    var obj = [];
    obj = {
        id: "0",
        ClassName: document.getElementById("classname").value,
        Name: document.getElementById("name").value,
        Phone: document.getElementById("phone").value,
        QQ: document.getElementById("qq").value,
        Email: document.getElementById("email").value,
        Remark: document.getElementById("remark").value
    };
    var str = JSON.stringify(obj);
    $.ajax({
        type: "POST",
        url: "/Appointment/Add",
        datatype: "json",
        data: { models: str },
        success: function (data) {
            if (data == true) {
                var t = alert('<strong>恭喜！</strong>您已经报名成功，我们会尽快和您取得联系！', {
                    'type': 'information ',
                    'title': '提示',
                    'buttons': [
                   { caption: 'Ok', callback: function () { location.href = "/Appointment/"; } },
                    ]
                });
            } else {
                alert('<strong>Sorry！</strong>系统已经记录您的信息，工作人员正在审核，我们会尽快和您取得联系！', {
                    'type': 'error ',
                    'title': '提示',
                    'buttons': [
                  { caption: 'Ok', callback: function () { location.href = "/Appointment/"; } },
                    ]
                });
            }
        },
        error: function (mesg) {
            alert(mesg);
        }
    });
}
$.getJSON("/Home/GetQQOnline", function (data, state) {
    if (data || data.data > 0) {
        $("#qqonline").empty();
        var html = "";
        $.each(data, function (index, value) {
            html = " <li><a target='_blank' href='tencent://message/?uin=" + value.qq + "&Site=qq&Menu=yes'><img border='0' src='http://wpa.qq.com/pa?p=1:" + value.qq + ":4+').TrimStart('+').TrimEnd('+')' alt=" + value.name + "/>" + value.name + " target='_blank'>" + value.qq + "</a></li>";
            $("#qqonline").append(html);
        });
        $("#qqonline").append("<li><span>电话：021-68861819</span> </li> <li><span>时间：9：00-18：00</span> </li>");
    } else {
        alert("tetst");
    }
});

var PageSize, TotalPage, TotalCount;
$.getJSON("/Scheduler/Get", { PageIndex: "1", PageSize: "35" }, function (data, state) {
    createList(data);
    PageSize = data.PageSize;
    TotalCount = data.TotalCount;
    TotalPage = data.TotalPage;
    createPage(PageSize, 10, TotalCount);
});
//构造列表
function createList(Data) {
    $(".coursetbody tr").remove();
    var html = "";
    $.each(Data, function (index, value) {
        html += "<tr><td style='width:230px'><a href='/Scheduler/Detail?id=" + value.id + "' >" + value.course + "</a></td><td>" + value.teacher + "</td><td>￥" + value.price + "</td><td>" + value.daterange + "天</td><td>" + value.address + "</td><td>" + jsonDateFormat(value.startdate) + " - " + jsonDateFormat(value.enddate) + "</td></tr>";
    });
    $(".coursetbody").append(html);
}
function createPage(pageSize, buttons, total) {
    $(".pagination").jBootstrapPage({
        pageSize: pageSize,
        total: total,
        maxPageButton: buttons,
        onPageClicked: function (obj, pageIndex) {
            $.getJSON("/Scheduler/Get", { PageIndex: pageIndex + 1, PageSize: PageSize }, function (data, state) {
 createList(data.Data);
 PageSize = data.PageSize;
 TotalCount = data.TotalCount;
 TotalPage = data.TotalPage;
            });
        }
    });
}
function jsonDateFormat(jsonDate) {//json日期格式转换为正常格式
    try {//出自http://www.cnblogs.com/ahjesus 尊重作者辛苦劳动成果,转载请注明出处,谢谢!
        var date = new Date(parseInt(jsonDate.replace("/Date(", "").replace(")/", ""), 10));
        var month = date.getMonth() + 1 < 10 ? "0" + (date.getMonth() + 1) : date.getMonth() + 1;
        var day = date.getDate() < 10 ? "0" + date.getDate() : date.getDate();
        var hours = date.getHours();
        var minutes = date.getMinutes();
        var seconds = date.getSeconds();
        var milliseconds = date.getMilliseconds();
        return date.getFullYear() + "年" + month + "月" + day + "日";
    } catch (ex) {//出自http://www.cnblogs.com/ahjesus 尊重作者辛苦劳动成果,转载请注明出处,谢谢!
        return "";
    }
}
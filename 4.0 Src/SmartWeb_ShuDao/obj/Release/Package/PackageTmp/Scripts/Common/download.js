var PageSize, TotalPage, TotalCount;
$.getJSON("/Download/GetDownloadList", { PageIndex: "1", PageSize: "8" }, function (data, state) {
    createList(data.Data);
    PageSize = data.PageSize;
    TotalCount = data.TotalCount;
    TotalPage = data.TotalPage;
    createPage(PageSize, 10, TotalCount);
});
//构造列表
function createList(Data) {
    $(".downlist").remove();
    var html = "";
    $.each(Data, function (index, value) {
        html += "<div class='downlist'><dl><dt id='title'><a class='title' href='/Download/Detail?id=" + value.id + "' title='" + value.title + "'  target='_blank'>" + value.title + "</a></dt><dt><span>更新时间:" + date2str(parseDate(value.addtime), "yyyy-MM-dd") + "&nbsp;&nbsp;</span><span>文件大小:" + value.filesize + " KB&nbsp;&nbsp;</span><span>下载次数:" + value.hits + "&nbsp;&nbsp;</span><a id='btndownload' href='" + value.downloadurl + "' class='download' target='_blank' title='点击下载'><span>点击下载</span></a></dt></dt></dl></div>"
    });
    $("#product").append(html);
}
function createPage(pageSize, buttons, total) {
    $(".pagination").jBootstrapPage({
        pageSize: pageSize,
        total: total,
        maxPageButton: buttons,
        onPageClicked: function (obj, pageIndex) {
            $.getJSON("/Download/GetDownloadList", { PageIndex: pageIndex + 1, PageSize: PageSize }, function (data, state) {
                createList(data.Data);
                PageSize = data.PageSize;
                TotalCount = data.TotalCount;
                TotalPage = data.TotalPage;
            });
        }
    });
}
///// <summary>
/////	格式化显示日期时间
///// </summary>
///// <param name="x">待显示的日期时间，例如new Date()</param>
///// <param name="y">需要显示的格式，例如yyyy-MM-dd hh:mm:ss</param>
//function date2str(x, y) {
//    var z = { M: x.getMonth() + 1, d: x.getDate(), h: x.getHours(), m: x.getMinutes(), s: x.getSeconds() };
//    y = y.replace(/(M+|d+|h+|m+|s+)/g, function (v) { return ((v.length > 1 ? "0" : "") + eval('z.' + v.slice(-1))).slice(-2) });
//    return y.replace(/(y+)/g, function (v) { return x.getFullYear().toString().slice(-v.length) });
//}
//function parseDate(str) // 这个函数用来把字符串转换为日期格式
//{
//    return new Date(Date.parse(str.replace(/-/g, "/")));
//}

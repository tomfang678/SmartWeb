var PageSize, TotalPage, TotalCount, NewsType;
$.getJSON("/Home/GetActiveList", { newstype: "1", PageIndex: "1", PageSize: "6" }, function (data, state) {
    createList(data);
    PageSize = data.PageSize;
    TotalCount = data.TotalCount;
    TotalPage = data.TotalPage;
    NewsType = "5";
    createPage(PageSize, 10, TotalCount);
});
//构造列表
function createList(data) {
    $("#product li").remove();
    var html = "";
    $.each(data, function (index, value) {
        html += " <li><a href='/Home/Detail?id=" + value.id + "' title='" + value.title + "' target='_blank'> <img src='" + value.imgurl + "' alt='" + value.title + "' /></a> <h3><a  href='/Home/Detail?id=" + value.id + "' title='" + value.title + "' target='_blank'>" + value.title + "</a></h3></li>";
    });
    $("#product").append(html);
}
function createPage(pageSize, buttons, total) {
    $(".pagination").jBootstrapPage({
        pageSize: pageSize,
        total: total,
        maxPageButton: buttons,
        onPageClicked: function (obj, pageIndex) {
            $.getJSON("/Home/GetActiveList", { newstype: "1", PageIndex: pageIndex + 1, PageSize: PageSize }, function (data, state) {
                createList(data.Data);
                PageSize = data.PageSize;
                TotalCount = data.TotalCount;
                TotalPage = data.TotalPage;
            });
        }
    });
}
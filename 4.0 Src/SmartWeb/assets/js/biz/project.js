var PageSize, TotalPage, TotalCount;
$.getJSON("/Project/GetProductList", { PageIndex: "1", PageSize: "10" }, function (data, state) {
    createList(data.Data);
    PageSize = data.PageSize;
    TotalCount = data.TotalCount;
    TotalPage = data.TotalPage;
    createPage(PageSize, 10, TotalCount);
});
//构造列表
function createList(Data) {
    $("#jlglcase dl").remove();
    var html = "";
    $.each(Data, function (index, value) {
        var desc = "";
        if (value.description != null) {
            desc = value.description.substring(0, 200);
        }
        html += "<dl> <dt><a href='/Project/Detail?id=" + value.id + "' target='_blank'><img alt='" + value.title + "' title='" + value.title + "' src='" + value.imgurl + "' width='150' height='130' /></a> </dt><dd><p><font face=Verdana>名称：" + value.title + "</font></p><p class='time'>价格：<span style='color:#ff0000;font-weight:bold;font-size: 13px'>￥" + value.price + "</span></p><p><font face=Verdana>概述：" + desc + "...</div></dd></dl><div class='line-gray'></div>"
    });
    $("#jlglcase").append(html);
}
function createPage(pageSize, buttons, total) {
    $(".pagination").jBootstrapPage({
        pageSize: pageSize,
        total: total,
        maxPageButton: buttons,
        onPageClicked: function (obj, pageIndex) {
            $.getJSON("/Project/GetProductList", { PageIndex: pageIndex + 1, PageSize: PageSize }, function (data, state) {
                createList(data.Data);
                PageSize = data.PageSize;
                TotalCount = data.TotalCount;
                TotalPage = data.TotalPage;
            });
        }
    });
}

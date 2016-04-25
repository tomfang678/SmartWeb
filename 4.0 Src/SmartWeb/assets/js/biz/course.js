var PageSize, TotalPage, TotalCount;
$.getJSON("/ExcellentCourse/GetProductList", { PageIndex: "1", PageSize: "4" }, function (data, state) {
    createList(data.Data);
    PageSize = data.PageSize;
    TotalCount = data.TotalCount;
    TotalPage = data.TotalPage;
    createPage(PageSize, 10, TotalCount);
});
//构造列表
function createList(Data) {
    $("#course li").remove();
    var html = "";
    $.each(Data, function (index, value) {
        var desc="";
        if ( value.description!=null) {
            desc = value.description.substring(0, 200);
        }
        html += "<li class='c'> <a class='img fl' href='/ExcellentCourse/Detail?id=" + value.id + "' target='_blank'><img src=" + value.imgurl + "></a><div class='info fl'><p class='vtitle'><a href='/ExcellentCourse/Detail?id=" + value.id + "' target='_blank'>课程名称：" + value.title + "</a></p><p class='time'>价格：<span style='color:#ff0000;font-weight:bold;font-size: 13px'>￥" + value.price + "</span></p><p class='desc'>概述：" + desc + "</p></p></div></li>";
    });
    $("#course").append(html);
}
function createPage(pageSize, buttons, total) {
    $(".pagination").jBootstrapPage({
        pageSize: pageSize,
        total: total,
        maxPageButton: buttons,
        onPageClicked: function (obj, pageIndex) {
            $.getJSON("/ExcellentCourse/GetProductList", { PageIndex: pageIndex + 1, PageSize: PageSize }, function (data, state) {
                createList(data.Data);
                PageSize = data.PageSize;
                TotalCount = data.TotalCount;
                TotalPage = data.TotalPage;
            });
        }
    });
}
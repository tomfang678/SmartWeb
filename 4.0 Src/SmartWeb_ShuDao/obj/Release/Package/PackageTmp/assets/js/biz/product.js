var PageSize, TotalPage, TotalCount;
$.getJSON("/Product/GetList", { PageIndex: "1", PageSize: "10" }, function (data, state) {
    createList(data.Data);
    PageSize = data.PageSize;
    TotalCount = data.TotalCount;
    TotalPage = data.TotalPage;
    createPage(PageSize, 10, TotalCount);
});
//构造列表
function createList(Data) {
    if (Data && arr.Data > 0) {
        $("#prodct_list").empty();
    }
    var html = "";
    $.each(Data, function (index, value) {
        var desc = "";
        if (value.description != null) {
            desc = value.description.substring(0, 100);
        }
        html += "<section> <a href='product_detail.html?id=" + value.id + "'><img alt='" + value.title + "' title='" + value.title + "' src='" + value.imgurl + "' style='width:90%;height:200px' /></a><h3><a href='product_detail.html?id=" + value.id + "' alert=''>" + value.title + "</a></h3><p>" + value.keywords + "&nbsp;&nbsp;&nbsp;&nbsp;<b>￥" + value.price + "</b></p></a><p>" + desc + "...</p></section>";
        var t = index ? index % 2 ? "true" : "false" : "0"
        if(t=="true")
        {
            $("#prodct_list").append("<div class='features-row'>" + html + "</div>");
            html = "";
        }
    });
    if (html!="") {
        $("#prodct_list").append("<div class='features-row'>" + html + "</div><ul class='pagination'></ul>");
    }
}
function createPage(pageSize, buttons, total) {
    $(".pagination").jBootstrapPage({
        pageSize: pageSize,
        total: total,
        maxPageButton: buttons,
        onPageClicked: function (obj, pageIndex) {
            $.getJSON("/Product/GetList", { PageIndex: pageIndex + 1, PageSize: PageSize }, function (data, state) {
                createList(data.Data);
                PageSize = data.PageSize;
                TotalCount = data.TotalCount;
                TotalPage = data.TotalPage;
            });
        }
    });
}

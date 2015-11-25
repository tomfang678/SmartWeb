var PageSize, TotalPage, TotalCount;
$.getJSON("/Case/GetList", { PageIndex: "1", PageSize: "10" }, function (data, state) {
    createList(data.Data);
    PageSize = data.PageSize;
    TotalCount = data.TotalCount;
    TotalPage = data.TotalPage;
    createPage(PageSize, 10, TotalCount);
});
//构造列表
function createList(Data) {
    var html = "";
    if (Data && Data.data > 0) {
        $("#zgcase").empty();
        $.each(Data, function (index, value) {
            var desc = "";
            if (value.description != null) {
                desc = value.description.substring(0, 100) + "...";
            }
            html += "<div class='6u 12u(narrower)'><section class='box special'><span class='image featured'><img alt='" + value.title + "' title='" + value.title + "' src='" + value.imgurl + "' /></span><h3>" + value.title + "</h3><p>" + desc + "</p><a  href='/case_detail.html?id=" + value.id + "' target='_blank' class='button alt'>More...</a></section></div>";
            var t = index ? index % 2 ? "true" : "false" : "0"
            if (t == "true") {
                $("#zgcase").append(" <div class='row'>" + html + "</div>");
                html = "";
            }
        });
    }
    if (html != "") {
        $("#zgcase").append(" <div class='row'>" + html + "</div>");
    }
}
function createPage(pageSize, buttons, total) {
    $(".pagination").jBootstrapPage({
        pageSize: pageSize,
        total: total,
        maxPageButton: buttons,
        onPageClicked: function (obj, pageIndex) {
            $.getJSON("/Case/GetList", { PageIndex: pageIndex + 1, PageSize: PageSize }, function (data, state) {
                createList(data.Data);
                PageSize = data.PageSize;
                TotalCount = data.TotalCount;
                TotalPage = data.TotalPage;
            });
        }
    });
}

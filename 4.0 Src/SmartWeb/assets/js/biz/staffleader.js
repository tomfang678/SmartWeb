var PageSize, TotalPage, TotalCount;
var stfid = $("#stafftype").val();
$.get("/Staff/GetStaffStarList?stafftype=" + stfid, { PageIndex: "1", PageSize: "15" }, function (data, state) {
    createList(data);
    PageSize = data.PageSize;
    TotalCount = data.TotalCount;
    TotalPage = data.TotalPage;
    createPage(PageSize, 10, TotalCount);
});
//构造列表
function createList(Data) {
    $("#staffstar dl").remove();
    var html = "";
    $.each(Data, function (index, value) {
        var desc = "";
        if (value.shortdesc != null) {
            desc = value.shortdesc.substring(0, 200);
        }
        html += "<dl><dt> <a href='/Staff/LeadershipDetail?staffid=" + value.id + "'><img src=" + value.imgurl + " alt='" + value.title + "' title='" + value.title + "'style='width:190px; height:160px' /></a></dt><dd><font face=Verdana><font face=Verdana><span style='font-size:13px;font-weight:bold'>" + value.title + "</span>" + desc + "</font></font> </dd> </dl><div class='line-gray'></div>";
    });
    $("#staffstar").append(html);
}
function createPage(pageSize, buttons, total) {
    $(".pagination").jBootstrapPage({
        pageSize: pageSize,
        total: total,
        maxPageButton: buttons,
        onPageClicked: function (obj, pageIndex) {
            $.getJSON("/Staff/GetStaffStarList?stafftype=" + stfid, { PageIndex: pageIndex + 1, PageSize: PageSize }, function (data, state) {
                createList(data.Data);
                PageSize = data.PageSize;
                TotalCount = data.TotalCount;
                TotalPage = data.TotalPage;
            });
        }
    });
}





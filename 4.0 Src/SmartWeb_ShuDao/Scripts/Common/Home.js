//*************************flash*****************************
$(document).ready(function () {
    $('.box_skitter_large').css({ width: 980, height: 300 }).skitter({
        numbers: false, interval: 3000, theme: 'clean', preview: true
        //  animation: 'blind', interval: 2000, hideTools: true, theme: 'minimalist'
    });
    //*************************公司简介*****************************
    $.post("/Home/GetAbout",
               { "topsize": 1 }
               , function (data, textStatus) {
                   var txthtml = "";
                   //$.each(data, function (index, element) {
                   txthtml += data.shortDesc;
                   //});
                   $("#companyabout").html(txthtml);
               }, "json");
    //*************************取新闻Top5*****************************
    $.post("/Home/GetTopNews",
               { "topsize": 5 }
               , function (data, textStatus) {
                   var txthtml = "<ol class='list-none metlist'>";
                   $.each(data, function (index, element) {

                       txthtml += " <li class='list '><span class='time'>" + element.addtime + "</span><a href='/News/Detail?id=" + element.id + "' title='" + data.title + "' target='_self'>" + element.title + "</a></li>";
                   });
                   txthtml += " </ol>";
                   $("#companynews").html(txthtml);
               }, "json");
    //*************************行业资讯*****************************
    $.post("/Home/GetTopHyNews",
               { "topsize": 5 }
               , function (data, textStatus) {
                   var txthtml = "<ol class='list-none metlist'>";
                   $.each(data, function (index, element) {

                       txthtml += " <li class='list '><span class='time'>" + element.addtime + "</span><a href='/News/Detail?id=" + element.id + "' title='" + data.title + "' target='_self'>" + element.title + "</a></li>";
                   });
                   txthtml += " </ol>";
                   $("#HyNews").html(txthtml);
               }, "json");

    //*************************招聘信息*****************************
    $.post("/Home/GetTopHRNews",
               { "topsize": 5 }
               , function (data, textStatus) {
                   var txthtml = "<ol class='list-none metlist'>";
                   $.each(data, function (index, element) {

                       txthtml += " <li class='list '><span class='time'>" + element.addtime + "</span><a href='/Job/Detail?id=" + element.id + "' title='" + data.position + "' target='_self'>" + element.position + "</a></li>";
                   });
                   txthtml += " </ol>";
                   $("#HRNews").html(txthtml);
               }, "json");
});
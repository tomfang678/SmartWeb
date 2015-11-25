/// <summary>
///	格式化显示日期时间
/// </summary>
/// <param name="x">待显示的日期时间，例如new Date()</param>
/// <param name="y">需要显示的格式，例如yyyy-MM-dd hh:mm:ss</param>
function date2str(x, y) {
    var z = { M: x.getMonth() + 1, d: x.getDate(), h: x.getHours(), m: x.getMinutes(), s: x.getSeconds() };
    y = y.replace(/(M+|d+|h+|m+|s+)/g, function (v) { return ((v.length > 1 ? "0" : "") + eval('z.' + v.slice(-1))).slice(-2) });
    return y.replace(/(y+)/g, function (v) { return x.getFullYear().toString().slice(-v.length) });
}
function parseDate(str) // 这个函数用来把字符串转换为日期格式
{
    return new Date(Date.parse(str.replace(/-/g, "/")));
}
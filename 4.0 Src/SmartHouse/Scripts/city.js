(function (global) {
    //域配置，方便开发调试
    var suffix = ".uoko.com";
    //首页地址
    var homePage = "http://www" + suffix;
    //城市数据
    var jsonData = {
        "chengdu": {
            "url": "http://www" + suffix,
            "host": "www" + suffix,
            "value": "成都",
            "default": true,
        },
        "beijing": {
            "url": "http://beijing" + suffix,
            "host": "beijing" + suffix,
            "value": "北京",
            "default": false,
        },
        "wuhan": {
            "url": "http://wuhan" + suffix,
            "host": "wuhan" + suffix,
            "value": "武汉",
            "default": false,
        },
    };
    /**
     * 操作cookie中city的相关方法
     */
    var cityMethods = (function () {
        var cookieCityName = "city";
        var obj = {
            //获取cookie中city的值
            get: function () {
                return uoko.cookie.get(cookieCityName) || "";
            },
            //设置cookie中city的值
            set: function (cookieCityValue) {
                uoko.cookie.set(cookieCityName, cookieCityValue);
            }
        };
        return obj;
    })();

    /**
     * 判断用户所在城市
     */
    function judgeCity() {
        var urlHost = location.host, //当前Url的host
            urlCity; //当前Url所在城市站
        for (var attr in jsonData) {
            if (jsonData[attr]["host"] === urlHost) {
                urlCity = attr;
                break;
            }
        }
        var cookieCity = cityMethods.get();
        //如果cookie中city的值为'chengdu'，return
        if (cookieCity === "chengdu") {
            return;
        }
        //如果用户url表示的城市站与cookie中默认城市不相符，跳转到cookie默认的城市站
        if (urlCity !== cookieCity) {
            location.href = jsonData[cookieCity]["url"];
        }
    }

    /**
     * 设置cookie中city的值为jsonData中default为true的城市
     */
    function setDefaultCityCookie() {
        for (var attr in jsonData) {
            if (jsonData[attr]["default"]) {
                cityMethods.set(attr);
                break;
            }
        }
    }

    /**
     * 根据用户IP判断用户所在城市
     */
    function ipToCityFun() {
        $.ajax({
            async: false,
            url: "http://int.dpool.sina.com.cn/iplookup/iplookup.php?format=js",
            type: "get",
            dataType: "script",
            timeout: 2000,
            //如果请求成功
            success: function () {
                var cityCookieValue = (remote_ip_info.city).replace(/\s/g, "");
                for (var attr in jsonData) {
                    if (jsonData[attr]["value"] === cityCookieValue) {
                        cityMethods.set(attr);
                        break;
                    }
                    //如果用户所在城市信息没有在jsonData中，设置默认的城市
                    setDefaultCityCookie();
                }
                judgeCity();
            },
            //如果请求失败
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                setDefaultCityCookie();
                judgeCity();
            }
        })
    }

    function init() {
        var regexp = new RegExp("^" + homePage + "/{0,1}$", "i");
        //如果访问的不是www.uoko.com，return
        if (!(regexp.test(location.href))) {
            return;
        }
        //如果访问的是www.uoko.com，但默认城市是'chengdu'，return
        if ((regexp.test(location.href)) && cityMethods.get() === "chengdu") {
            return;
        }
        //如果cookie默认城市不存在，获取IP地址并判断用户所在城市
        if (!cityMethods.get()) {
            ipToCityFun();
            return;
        }
        //如果cookie默认城市存在，判断用户所在城市
        judgeCity();
    }

    //执行初始化
    init();

})(window);
// データを配列で管理
var datas = [];

// データを追加
function addJsonData(jsonObj) {
    jsonObj.id = datas.length + 1;
    datas.push(jsonObj);
}

// データをcsv形式にし、ダウンロード

function downloadJsonData() {
    let loghead = "success,fish_number,clear_time,distance,sensitivity,limited_time,maximum_speed,acceleration,friction\n";
    let logdata = "";
    datas.map(function (d) {
        logdata += d.Success + "," + d.FishNumber + "," + d.ClearTime + "," + d.MovingDistance + "," + d.Sensitivity + "," + d.LimitedTime + ","
            + d.MaximumSpeed + "," + d.Acceleration + "," + d.Friction + "\n";
    });
   

    const filename = getNow() + ".csv";
    const bom = new Uint8Array([0xef, 0xbb, 0xbf]);
    const blob = new Blob([bom, loghead + logdata], { type: "text/csv" });

    if (window.navigator.msSaveBlob) {
        window.navigator.msSaveBlob(blob, filename);
    } else {
        const url = (window.URL || window.webkitURL).createObjectURL(blob);
        const download = document.createElement("a");
        download.href = url;
        download.download = filename;
        download.click();
        (window.URL || window.webkitURL).revokeObjectURL(url);
    }
}


// 時刻を取得
function getNow() {
    var date = new Date();
    var yyyy = date.getFullYear();
    var mm = toDoubleDigits(date.getMonth() + 1);
    var dd = toDoubleDigits(date.getDate());
    var hh = toDoubleDigits(date.getHours());
    var mi = toDoubleDigits(date.getMinutes());
    return yyyy + mm + dd + '_' + hh + mi;
}
function toDoubleDigits(num) {
    num += "";
    if (num.length === 1) {
        num = "0" + num;
    }
    return num;   
}

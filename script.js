// データを配列で管理
var datas = [];

// データを追加
function add_data(jsonObj) {
    jsonObj.id = datas.length + 1;
    datas.push(jsonObj);
}

// データをcsv形式にし、ダウンロード
/*
function download_data() {
    let loghead = "id,score,hit_num,hit_rate\n";
    let logdata = "";
    datas.map(function (d) {
        logdata += d.id + "," + d.score + "," + d.hit_num + "," + d.hit_rate + "\n";
    });
    */
    function download_data() {
        //let loghead = "name,age,success,fish_num,clear_time,distance";
        let loghead = "名前,年齢,成功/失敗,獲得した魚の数,クリア時間,到達距離\n";
        let logdata = "";
        datas.map(function (d) {
            logdata += d.name+","+d.age+","+d.success+","+d.fish_num+","+d.clear_time +","+d.distance + "\n";
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
/*
function download_data() {
    let loghead2 = "name,age,distance,up_on,up_off\n";
    let logdata2 = "";
    datas.map(function (d) {
        logdata2 += d.name+","+d.age+","+d.up_on+","+d.up_off+"\n";
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
*/

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

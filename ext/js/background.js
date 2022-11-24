/* pattern 1 */
// Edge 起動時にネイティブ アプリを起動
const port = chrome.runtime.connectNative("jp.midoliy.app");
// ネイティブ アプリからメッセージが来た時の処理
port.onMessage.addListener((req) => {
  console.log('msg:', req)
})
// ネイティブ アプリとの通信が終了した時の処理
port.onDisconnect.addListener((req) => {
  console.log('dosconnect:', req)
})
// content.js (またはコンテンツ) からメッセージが来た時の処理
chrome.runtime.onMessage.addListener(function (msg) {
  port.postMessage(msg);
});

// chrome.runtime.onMessage.addListener(function (msg) {
//   /* pattern 2 */
//   // chrome.runtime.sendNativeMessage('jp.midoliy.app',
//   //   msg,
//   //   function (response) {
//   //     console.log("msg:", response);
//   //   });
// });

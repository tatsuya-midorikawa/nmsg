/* pattern 1 */
const port = chrome.runtime.connectNative("jp.midoliy.app");
port.onMessage.addListener((req) => {
  console.log('msg:', req)
})
port.onDisconnect.addListener((req) => {
  console.log('dosconnect:', req)
})
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

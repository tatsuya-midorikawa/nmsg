chrome.runtime.onMessage.addListener(function (msg) {

  /* pattern 1 */
  const port = chrome.runtime.connectNative("jp.midoliy.app");
  port.onMessage.addListener((req) => {
    console.log('msg:', req)
  })
  port.postMessage(msg);

  /* pattern 2 */
  // chrome.runtime.sendNativeMessage('jp.midoliy.app',
  //   msg,
  //   function (response) {
  //     console.log("msg:", response);
  //   });
});
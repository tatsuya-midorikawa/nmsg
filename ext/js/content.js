const btn = document.getElementById('btn');

if (btn) {
  btn.addEventListener('click', function(e) {
    chrome.runtime.sendMessage({ text: 'Hello' });
  });
}
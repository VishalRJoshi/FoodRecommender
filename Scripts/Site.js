function savor(button, id, title) {
  var xhr = new XMLHttpRequest();
  xhr.onreadystatechange = function() {
    if (xhr.readyState == 4) {
      alert('Your preference for ' + title + ' has been recorded. Thanks!');
    }
  }
  xhr.open('POST', 'Savor?recipe=' + id, true);
  xhr.send();
}

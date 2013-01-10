function savor(button, id, title) {
  var xhr = new XMLHttpRequest();
  xhr.onreadystatechange = function() {
  }
  xhr.open('POST', 'Savor?recipe=' + id, true);
  xhr.send();

  button.disabled = true;
}

function printIframeContent(iframeId) {

    var iframe = document.getElementById(iframeId);
    var iframeDoc = iframe.contentDocument || iframe.contentWindow.document;
    var divContents = iframe.parentElement.querySelector("div").innerHTML;
    iframeDoc.open();
    iframeDoc.write('<html><head><title>Print</title></head><body>');
    iframeDoc.write(divContents);
    iframeDoc.write('</body></html>');
    iframeDoc.close();
    iframe.contentWindow.focus();
    iframe.contentWindow.print();

}
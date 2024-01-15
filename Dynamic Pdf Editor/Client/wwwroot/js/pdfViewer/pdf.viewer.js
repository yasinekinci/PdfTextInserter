

window.MyJS = {
    pdfDoc: null,
    MyComponentReference: null,
    ShowPageNumber: 1,
    CacheMyComponent: function (componentReference) {
        MyJS.MyComponentReference = componentReference;
    },
    GetPageCount: function (pageCount) {
        MyJS.MyComponentReference.invokeMethodAsync('GetPageCount', pageCount);
    },
    SetPageData: function (data) {
        var pdfData = atob(data);
        var { pdfjsLib } = globalThis;
        pdfjsLib.GlobalWorkerOptions.workerSrc = 'js/pdfviewer/pdf.worker.mjs';
        pdfjsLib.getDocument({ data: pdfData }).promise.then(function (pdfDoc_) {
            pdfDoc = pdfDoc_;
            MyJS.GetPageCount(pdfDoc.numPages);
            MyJS.ShowPageByNumber();
        });
    },
    ShowPageByNumber: function (number) {
        if (number) {
            MyJS.ShowPageNumber = number;
        }
        pdfDoc.getPage(MyJS.ShowPageNumber).then(function (page) {
            var pdfContainer = document.getElementById('pdfContainer');
            pdfContainer.innerHTML = null;
            const viewport = page.getViewport({ scale: 2 });
            const canvas = document.createElement('canvas');
            canvas.style = "width: 100%;";
            canvas.className = "pdfContent";
            canvas.width = viewport.width;
            canvas.height = viewport.height;
            page.render({ canvasContext: canvas.getContext('2d'), viewport: viewport });
            pdfContainer.appendChild(canvas);
        });
    }
}
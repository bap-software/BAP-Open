const localizationHiddenValueClassName = "hidden-value";

function getReadValueDiv(itemIndex) {
    return document.getElementById("read-value-div-" + itemIndex);
}

function getEditValueDiv(itemIndex) {
    return document.getElementById("edit-value-div-" + itemIndex);
}

function getReadValueSpan() {
    return document.getElementById("read-value-span");
}

function getSaveValueBtn() {
    return document.getElementById("save-value-btn");
}

function getOldValueInput(itemIndex) {
    return document.getElementById("old-localization-value-" + itemIndex);
}

function hideReadValueDiv(itemIndex) {
    getReadValueDiv(itemIndex).classList.add(localizationHiddenValueClassName);
}

function hideEditValueDiv(itemIndex) {
    getEditValueDiv(itemIndex).classList.add(localizationHiddenValueClassName);
}

function showReadValueDiv(itemIndex) {
    getReadValueDiv(itemIndex).classList.remove(localizationHiddenValueClassName);
}

function showEditValueDiv(itemIndex) {
    getEditValueDiv(itemIndex).classList.remove(localizationHiddenValueClassName);
}

function getSpanWithReadableLocalizationValue(itemIndex) {
    return getReadValueDiv(itemIndex).getElementsByTagName("span")[0];
}

function getInputWithLocalizationValue(itemIndex) {
    return getEditValueDiv(itemIndex).getElementsByTagName("input")[0];
}



function onEditLocalizationValueClick(itemId, itemIndex) {
    showEditValueDiv(itemIndex);
    hideReadValueDiv(itemIndex);
}

function onResetLocalizationValue(itemId, itemIndex) {
    showReadValueDiv(itemIndex);
    hideEditValueDiv(itemIndex);

    var oldValue = document.getElementById("old-localization-value-" + itemIndex).value;

    getInputWithLocalizationValue(itemIndex).value = oldValue;
    getSpanWithReadableLocalizationValue(itemIndex).innerHTML = oldValue;
}
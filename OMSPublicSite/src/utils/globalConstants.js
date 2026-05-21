export let countries = []; //window.appConfig.countries;
export let default_currency = {}; //window.appConfig.default_currency;
export let default_language = {}; //window.appConfig.default_language;
export let default_strings = {}; //window.appConfig.default_strings;
export let allLanguages = []; //window.appConfig.allLanguages;
export let appSocials = {}; //window.appConfig.appSocials;
export let slider_speed ="";

export const set_countries = function (val) {
    countries = val;
};
export const set_default_currency = function (val) {
    default_currency = val;
};
export const set_default_language = function (val) {
    default_language = val;
};
export const set_default_strings = function (val) {
    default_strings = val;
};
export const set_allLanguages = function (val) {
    allLanguages = val;
};
export const set_appSocials = function (val) {
    appSocials = val;
};

export const set_slider_speed = function (val) {
    slider_speed = val;
}

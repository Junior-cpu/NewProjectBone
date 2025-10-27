
window.localStorageHelper = {
    saveList: function (key, list) {
        localStorage.setItem(key, JSON.stringify(list));
    },
    getList: function (key) {
        return localStorage.getItem(key);
    },
    removeList: function (key) {
        localStorage.removeItem(key);
    }
};

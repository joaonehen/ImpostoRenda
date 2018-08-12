const URL = 'http://localhost:51394/api'
export default {
    post(path, body) {
        var headers = {
            'Content-Type': 'application/json',
        }
        const promise = new Promise((resolve, reject) => {
            try {
                fetch(URL + path, {
                    method: 'POST',
                    headers: headers,
                    body: JSON.stringify(body)
                })
                    .then((response) => {
                        if (response.status === 200) {
                            response.json().then((data) => {
                                resolve(data)
                            })
                        } else {
                            response.json().then((error) => {
                                reject(error)
                            })
                        }
                    })
            } catch (e) {
                console.error(e);
            }
        })

        return promise
    },
    get(path, parameters) {
        var headers = {
            'Content-Type': 'application/json',
        }
        const promise = new Promise((resolve, reject) => {
            try {
                var qs = "";
                for (var key in parameters) {
                    var value = parameters[key];
                    qs += encodeURIComponent(key) + "=" + encodeURIComponent(value) + "&";
                }
                if (qs.length > 0) {
                    qs = qs.substring(0, qs.length - 1); //chop off last "&"
                    path = path + "?" + qs;
                }
                fetch(URL + path, {
                    method: 'GET',
                    headers: headers,
                })
                    .then((response) => {
                        if (response.status === 200) {
                            response.json().then((data) => {
                                resolve(data)
                            })
                        } else {
                            response.json().then((error) => {
                                reject(error)
                            })
                        }
                    })
            } catch (e) {
                console.error(e);
            }
        })

        return promise
    },
}

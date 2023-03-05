(() => {

    const publicKey = `-----BEGIN PUBLIC KEY-----
MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQDGy8btrbnSNPz7vWKfQXKxKXzg
28ZD8jCAd7gGYfUIFqKqUcogHWt5gyGvTgEhwBwBP1kYrVnBlhB2nuWHLYpJDI6b
uBoqKrHtrcdgXsKumSP0OKpn0nbYxknOvNYVjUUR6plMboUBaWX1oKoR6pNzTEHS
al4bIU7XMwppkR3KNQIDAQAB
-----END PUBLIC KEY-----`;

    function getSpkiDer(spkiPem) {
        const pemHeader = "-----BEGIN PUBLIC KEY-----";
        const pemFooter = "-----END PUBLIC KEY-----";
        var pemContents = spkiPem.substring(
            pemHeader.length,
            spkiPem.length - pemFooter.length
        );
        var binaryDerString = window.atob(pemContents);
        return str2ab(binaryDerString);
    }

    async function importPublicKey(spkiPem) {
        return await window.crypto.subtle.importKey(
            "spki",
            getSpkiDer(spkiPem),
            {
                name: "RSA-OAEP",
                hash: "SHA-1",
            },
            true,
            ["encrypt"]
        );
    }

    async function encryptRSA(key, plaintext) {
        let encrypted = await window.crypto.subtle.encrypt(
            {
                name: "RSA-OAEP",
            },
            key,
            plaintext
        );
        return encrypted;
    }

    function str2ab(str) {
        const buf = new ArrayBuffer(str.length);
        const bufView = new Uint8Array(buf);
        for (let i = 0, strLen = str.length; i < strLen; i++) {
            bufView[i] = str.charCodeAt(i);
        }
        return buf;
    }

    function ab2str(buf) {
        return String.fromCharCode.apply(null, new Uint8Array(buf));
    }

    async function encrypt(plaintext) {
        const pub = await importPublicKey(publicKey);
        const encrypted = await encryptRSA(
            pub,
            new TextEncoder().encode(plaintext)
        );
        const encryptedBase64 = window.btoa(ab2str(encrypted));
        console.log(encryptedBase64);
    }

    encrypt("I want to decrypt this string in C#");

})();
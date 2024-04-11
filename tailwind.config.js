module.exports = {

    tailwindConfig: './tailwind.config.js',

    content: [
        './Pages/**/*.cshtml',
        './Views/**/*.cshtml',
        './Account/**/*.cshtml'
    ],
    theme: {
        extend: {},
    },
    plugins: [


        require('@tailwindcss/forms'),
        require('tailwindcss'),
        require('@headlessui/tailwindcss'),
        require('@headlessui/react'),
        require('tailwindcss-animated'),



    ],


}
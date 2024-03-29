module.exports = {

    tailwindConfig: './styles/tailwind.config.js',

    content: [
       './Pages/**/*.cshtml',
       './Views/**/*.cshtml'
],
    theme: {
        extend: {},
    },
    plugins: [


        require('@tailwindcss/forms'),
        require('tailwindcss'),
        require('@headlessui/tailwindcss'),
        require('tailwindcss-animated'),
        


    ],
}

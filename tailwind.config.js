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


        ['prettier-plugin-tailwindcss'],
        require('tailwindcss'),
        require('@headlessui/tailwindcss'),


    ],
}

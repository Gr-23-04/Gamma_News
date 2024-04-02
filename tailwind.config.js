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
        require('@tailwindcss/forms'),
        require('tailwindcss'),
        require('@headlessui/tailwindcss'),
        require('tailwindcss-animated'),


    ],


    module.exports = {
        theme: {
            extend: {
                colors: {
                    'custom-blue': '#1c82ca', // You can name it whatever you like
                },
            },
        },
    }

}

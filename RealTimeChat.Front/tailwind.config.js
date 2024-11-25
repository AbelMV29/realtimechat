/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./src/**/*.{html,ts}",
  ],
  theme: {
    extend: {
      colors:{
        'bg-primary':'#111827',
        'bg-secondary':'#1F2937',
        'bg-tertiary':'#374151',
        'hover':'#4b5563',
        'text-primary':'#f9fafb',
        'text-secondary':'#9CA3AF',
        'bg-message':'#2563eb',
        'bg-received':'#374151'
      }
    },
  },
  plugins: [],
}


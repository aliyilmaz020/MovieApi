// Toggle Sidebar
const toggleBtn = document.getElementById('toggleBtn');
const sidebar = document.getElementById('sidebar');
const mainContent = document.getElementById('mainContent');
const liveToast = document.getElementById('liveToast');

toggleBtn.addEventListener('click', () => {
    sidebar.classList.toggle('collapsed');
    sidebar.classList.toggle('show');
    mainContent.classList.toggle('expanded');
});

// Theme Toggle
const themeToggle = document.getElementById('themeToggle');
const html = document.documentElement;

themeToggle.addEventListener('click', () => {
    const currentTheme = html.getAttribute('data-theme');
    const newTheme = currentTheme === 'dark' ? 'light' : 'dark';
    html.setAttribute('data-theme', newTheme);

    const icon = themeToggle.querySelector('i');
    icon.className = newTheme === 'dark' ? 'fas fa-sun' : 'fas fa-moon';

    localStorage.setItem('theme', newTheme);
});

// Load saved theme
const savedTheme = localStorage.getItem('theme') || 'light';
html.setAttribute('data-theme', savedTheme);
const icon = themeToggle.querySelector('i');
icon.className = savedTheme === 'dark' ? 'fas fa-sun' : 'fas fa-moon';

// User Dropdown
const userProfile = document.getElementById('userProfile');
const userDropdown = document.getElementById('userDropdown');

userProfile.addEventListener('click', (e) => {
    e.stopPropagation();
    userDropdown.classList.toggle('show');
});

document.addEventListener('click', () => {
    userDropdown.classList.remove('show');
});
function toastr(title, body, color = 'bg-success') {
    debugger
    $('#toastrHeader').addClass(color)
    $('#toastrTitle').text(title);
    $('#toastrBody').text(body);
    const toastBootstrap = bootstrap.Toast.getOrCreateInstance(liveToast)
    toastBootstrap.show();
}
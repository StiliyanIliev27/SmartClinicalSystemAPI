# 🏥 SMART MEDICAL SYSTEM — FRONTEND DEVELOPMENT TODO

## 📋 Overview

This document outlines the complete frontend development plan for the Smart Clinical System. The frontend will be built using **React + TypeScript + TailwindCSS** with modern tools and best practices.

### Tech Stack
- ✔ React Router — for navigation
- ✔ TanStack Query — for data fetching and caching
- ✔ Axios — for API calls
- ✔ ShadCN UI — beautifully matches the "dashboard" style
- ✔ Redux Toolkit — for global state (auth, user roles)
- ✔ Recharts or Chart.js — for health trend visualizations

---

## Phase 1: Project Setup and Foundation

### 1.1 Initialize React + TypeScript Project
- [ ] Create React + TypeScript project (Vite recommended)
- [ ] Install core dependencies:
  - `react`, `react-dom`, `react-router-dom`
  - `@tanstack/react-query`
  - `axios`
  - `@reduxjs/toolkit`, `react-redux`
  - `tailwindcss`, `postcss`, `autoprefixer`
  - `recharts` (or `chart.js`)
  - `shadcn/ui` components
- [ ] Configure TailwindCSS
- [ ] Configure path aliases (`@/` for src)
- [ ] Set up ESLint + Prettier

### 1.2 Environment and API Configuration
- [ ] Create `.env` files (`.env.development`, `.env.production`)
- [ ] Set `VITE_API_BASE_URL` environment variable
- [ ] Configure Axios instance with base URL
- [ ] Set up Axios interceptors:
  - Request: attach access token from Redux store
  - Response: handle 401 errors, refresh token logic, error handling

### 1.3 TypeScript Types and Interfaces
- [ ] Create `types/` folder structure
- [ ] Define types:
  - `types/auth.ts` (User, LoginRequest, RegisterRequest, AuthResponse)
  - `types/user.ts` (UserProfile, Notification)
  - `types/healthLog.ts` (UserHealthLog, CreateHealthLogDto, UpdateHealthLogDto)
  - `types/medicine.ts` (Medicine, MedicineCategory enum)
  - `types/medicalReceipt.ts` (MedicalReceipt, MedicalReceiptMedicine)
  - `types/ai.ts` (DiagnoseResult, CompareResult, SummaryResult)
  - `types/api.ts` (ApiResponse, PaginatedResponse)

---

## Phase 2: State Management and Authentication

### 2.1 Redux Store Setup
- [ ] Install and configure Redux Toolkit store
- [ ] Create store structure:
  ```
  store/
  ├── index.ts
  ├── hooks.ts (typed hooks)
  └── slices/
      ├── authSlice.ts
      ├── userSlice.ts
      └── uiSlice.ts (theme, sidebar, etc.)
  ```

### 2.2 Auth Slice
- [ ] Create `authSlice.ts`:
  - State: `user`, `accessToken`, `isAuthenticated`, `roles`
  - Actions: `setCredentials`, `logout`, `updateToken`
- [ ] Create auth thunks:
  - `loginThunk`
  - `registerThunk`
  - `logoutThunk`
  - `refreshTokenThunk`

### 2.3 Auth Service Layer
- [ ] Create `services/authService.ts`:
  - `login(username, password)`
  - `register(username, email, password)`
  - `logout()`
  - `refreshToken()`
- [ ] Handle refresh token cookie automatically

### 2.4 Protected Routes
- [ ] Create `ProtectedRoute` component
- [ ] Create `RoleBasedRoute` component (Doctor, Admin)
- [ ] Set up route guards in router

---

## Phase 3: UI Components and Layout

### 3.1 ShadCN UI Setup
- [ ] Initialize ShadCN UI
- [ ] Configure theme (`components.json`)
- [ ] Install base components:
  - Button, Input, Label, Card
  - Dialog, Dropdown Menu
  - Table, Badge, Avatar
  - Form components
  - Toast/Toast notifications

### 3.2 Layout Components
- [ ] Create `layouts/` folder
- [ ] Build `MainLayout.tsx`:
  - Sidebar navigation
  - Top header with user menu
  - Breadcrumbs
  - Responsive design
- [ ] Create `AuthLayout.tsx` (for login/register pages)
- [ ] Create `DashboardLayout.tsx` (for dashboard pages)

### 3.3 Navigation
- [ ] Create `components/Navigation/Sidebar.tsx`
- [ ] Role-based menu items:
  - User/Patient: Dashboard, Health Logs, Medicines, AI Diagnosis
  - Doctor: Dashboard, Patients, Medical Receipts, Health Log Reviews
  - Admin: All above + Admin panel
- [ ] Create `components/Navigation/Header.tsx` with:
  - User avatar dropdown
  - Notifications bell
  - Logout button

### 3.4 Common Components
- [ ] `LoadingSpinner.tsx`
- [ ] `ErrorMessage.tsx`
- [ ] `EmptyState.tsx`
- [ ] `ConfirmDialog.tsx`
- [ ] `Pagination.tsx`
- [ ] `SearchBar.tsx`
- [ ] `DatePicker.tsx`

---

## Phase 4: Authentication Pages

### 4.1 Login Page
- [ ] Create `pages/auth/LoginPage.tsx`
- [ ] Form: username, password
- [ ] Handle errors
- [ ] Redirect after login (role-based)
- [ ] "Forgot password?" link (if implemented)

### 4.2 Register Page
- [ ] Create `pages/auth/RegisterPage.tsx`
- [ ] Form: username, email, password, confirm password
- [ ] Validation (email format, password strength)
- [ ] Success message + redirect to login

### 4.3 Auth Flow
- [ ] Implement automatic token refresh on app load
- [ ] Handle expired tokens gracefully
- [ ] Show loading state during auth check

---

## Phase 5: TanStack Query Setup and API Hooks

### 5.1 Query Client Configuration
- [ ] Set up `QueryClient` with defaults (refetch, staleTime, cacheTime)
- [ ] Create `providers/QueryProvider.tsx`
- [ ] Configure error handling and retry logic

### 5.2 API Hooks Structure
- [ ] Create `hooks/api/` folder
- [ ] Create hook files:
  - `useAuth.ts` (login, register, logout mutations)
  - `useHealthLogs.ts`
  - `useMedicines.ts`
  - `useMedicalReceipts.ts`
  - `useAI.ts`
  - `useNotifications.ts`

### 5.3 Health Logs Hooks
- [ ] `useGetHealthLogs(userId?)` — query
- [ ] `useGetHealthLogById(id)` — query
- [ ] `useCreateHealthLog()` — mutation
- [ ] `useUpdateHealthLog()` — mutation
- [ ] `useDeleteHealthLog()` — mutation
- [ ] `useSendHealthLogToDoctor()` — mutation

### 5.4 Medicines Hooks
- [ ] `useGetMedicines(pageNumber, pageSize)` — query
- [ ] `useGetMedicineById(id)` — query
- [ ] `useCreateMedicine()` — mutation (Doctor/Admin)
- [ ] `useUpdateMedicine()` — mutation (Doctor/Admin)
- [ ] `useDeleteMedicine()` — mutation (Doctor/Admin)

### 5.5 Medical Receipts Hooks (Doctor Role)
- [ ] `useGetMedicalReceipts(filters)` — query
- [ ] `useCreateMedicalReceipt()` — mutation
- [ ] `useUpdateMedicalReceipt()` — mutation

### 5.6 AI Hooks
- [ ] `useDiagnose(symptoms)` — mutation
- [ ] `useCompareMedicines(medicineIds, diagnosis)` — mutation
- [ ] `useSummaryCheck(period)` — query

### 5.7 Notifications Hooks
- [ ] `useGetNotifications()` — query with polling/real-time

---

## Phase 6: User Dashboard (Patient Role)

### 6.1 Dashboard Home
- [ ] Create `pages/dashboard/DashboardPage.tsx`
- [ ] Stats cards:
  - Total health logs
  - Recent AI consultations
  - Active prescriptions
  - Pending doctor reviews
- [ ] Recent activity timeline

### 6.2 Health Logs Management
- [ ] `pages/health-logs/HealthLogsPage.tsx`:
  - List with filters (date range, symptoms)
  - Create new health log button
  - Edit/Delete actions
- [ ] `pages/health-logs/CreateHealthLogPage.tsx`:
  - Form: symptoms, pain level (1-10), side effects, mood, temperature, notes
  - Validation
- [ ] `pages/health-logs/EditHealthLogPage.tsx`
- [ ] `pages/health-logs/HealthLogDetailPage.tsx`:
  - Show all details
  - "Send to Doctor" button (opens doctor selection)

### 6.3 Health Logs Charts
- [ ] Create `components/charts/HealthTrendsChart.tsx`:
  - Pain level over time (line chart)
  - Temperature trends
  - Mood distribution (pie/bar chart)
  - Symptoms frequency
- [ ] Integrate Recharts

### 6.4 Send Health Log to Doctor
- [ ] Create modal/component to select doctor
- [ ] List of patient's doctors
- [ ] Send action with confirmation

---

## Phase 7: Medicines Section

### 7.1 Medicines Catalog
- [ ] Create `pages/medicines/MedicinesPage.tsx`:
  - Search and filter (category, name)
  - Paginated table/list
  - Medicine cards with details
- [ ] Medicine detail view:
  - Generic name, category, strength, manufacturer
  - Description, indications, contraindications
  - Side effects, precautions
  - Price, stock quantity
  - AI summary if available

### 7.2 Medicine Management (Doctor/Admin)
- [ ] `pages/medicines/CreateMedicinePage.tsx`:
  - Full form with all fields
  - Category dropdown
  - Validation
- [ ] `pages/medicines/EditMedicinePage.tsx`
- [ ] Delete confirmation dialog

---

## Phase 8: AI Features

### 8.1 AI Diagnosis
- [ ] Create `pages/ai/DiagnosisPage.tsx`:
  - Symptoms input (textarea)
  - Submit button
  - Loading state
  - Results display:
    - Possible conditions
    - Recommended medicines (cards/links)
    - Advice/suggestions
  - History of past diagnoses

### 8.2 Medicine Comparison
- [ ] Create `pages/ai/CompareMedicinesPage.tsx`:
  - Medicine selector (2 medicines)
  - Diagnosis context input
  - Comparison results:
    - Side-by-side comparison table
    - Recommendations
    - Differences highlighted

### 8.3 Health Summary Check
- [ ] Create `pages/ai/SummaryCheckPage.tsx`:
  - Period selector (7, 30, 90 days)
  - Summary display:
    - Overall health trends
    - Most common symptoms
    - Pattern analysis
    - Recommendations
  - Visual charts/graphs

---

## Phase 9: Doctor Dashboard and Features

### 9.1 Doctor Dashboard
- [ ] Create `pages/doctor/DashboardPage.tsx`:
  - Stats: pending reviews, total patients, active receipts
  - Pending health logs to review
  - Recent medical receipts

### 9.2 Patient Health Logs Review
- [ ] Create `pages/doctor/HealthLogReviewsPage.tsx`:
  - List of health logs sent by patients
  - Filter: unread/viewed
  - Mark as viewed action
  - Detail view modal/page

### 9.3 Medical Receipts Management
- [ ] `pages/doctor/receipts/MedicalReceiptsPage.tsx`:
  - List with filters (patient, date range)
  - Create new receipt button
- [ ] `pages/doctor/receipts/CreateReceiptPage.tsx`:
  - Select patient (from doctor's patients)
  - Diagnosis input
  - Add medicines (search, quantity, duration, dosage instructions)
  - Advice textarea
  - Issue date, expiration date
- [ ] `pages/doctor/receipts/EditReceiptPage.tsx`
- [ ] `pages/doctor/receipts/ReceiptDetailPage.tsx`:
  - Full receipt view
  - Print/export option

### 9.4 Patients List
- [ ] Create `pages/doctor/PatientsPage.tsx`:
  - List of doctor's patients
  - View patient profile
  - View all patient health logs

---

## Phase 10: Notifications System

### 10.1 Notifications Component
- [ ] Create `components/Notifications/NotificationBell.tsx`:
  - Badge with unread count
  - Dropdown with notifications list
  - Mark as read
  - Click to navigate to related content

### 10.2 Notifications Page (Optional)
- [ ] `pages/notifications/NotificationsPage.tsx`:
  - Full list of notifications
  - Filter by type
  - Mark all as read

### 10.3 Real-time Updates (Optional)
- [ ] Set up polling or WebSocket for real-time notifications
- [ ] Update Redux store on new notifications

---

## Phase 11: Admin Features (If Needed)

### 11.1 Admin Dashboard
- [ ] Create `pages/admin/DashboardPage.tsx`:
  - System stats
  - User management
  - Medicine management access

### 11.2 User Management (If Needed)
- [ ] List all users
- [ ] Assign roles
- [ ] Activate/deactivate users

---

## Phase 12: Polish and Optimization

### 12.1 Error Handling
- [ ] Global error boundary
- [ ] API error handling (400, 401, 403, 404, 500)
- [ ] User-friendly error messages
- [ ] Error logging (optional: Sentry)

### 12.2 Loading States
- [ ] Skeleton loaders
- [ ] Loading spinners for async actions
- [ ] Optimistic updates where appropriate

### 12.3 Form Validation
- [ ] Use `react-hook-form` + `zod` (or similar)
- [ ] Validate on all forms
- [ ] Show validation errors clearly

### 12.4 Responsive Design
- [ ] Mobile-first approach
- [ ] Test on different screen sizes
- [ ] Mobile navigation (hamburger menu)

### 12.5 Accessibility
- [ ] ARIA labels
- [ ] Keyboard navigation
- [ ] Focus management
- [ ] Screen reader support

### 12.6 Performance
- [ ] Code splitting (lazy loading routes)
- [ ] Image optimization
- [ ] Memoization where needed
- [ ] Query caching optimization

### 12.7 UI/UX Enhancements
- [ ] Animations/transitions (Framer Motion optional)
- [ ] Toast notifications for success/error
- [ ] Confirm dialogs for destructive actions
- [ ] Empty states with helpful messages

---

## Phase 13: Testing and Finalization

### 13.1 Testing Setup
- [ ] Unit tests for utilities/hooks
- [ ] Integration tests for critical flows
- [ ] E2E tests (Cypress/Playwright) for main user journeys

### 13.2 Documentation
- [ ] README with setup instructions
- [ ] API integration docs
- [ ] Component documentation (Storybook optional)

### 13.3 Build and Deployment
- [ ] Configure build scripts
- [ ] Environment variables documentation
- [ ] Deployment configuration (Vercel/Netlify/AWS)
- [ ] CI/CD pipeline (optional)

---

## 🎯 Priority Order Recommendation

1. **Phase 1-2**: Setup + Auth (Foundation)
2. **Phase 3-4**: Basic UI + Login/Register (Can test auth)
3. **Phase 5**: API Hooks Setup (Data layer ready)
4. **Phase 6**: Patient Features (Main user flow)
5. **Phase 9**: Doctor Features (Second main flow)
6. **Phase 7-8**: Medicines + AI (Additional features)
7. **Phase 10-13**: Polish + Testing (Final touches)

---

## 📝 Important Notes

- **API Base URL**: Make sure it matches your backend URL
- **Refresh Token**: Handled via HTTP-only cookies, ensure credentials are included in requests
- **Roles**: User (Patient), Doctor, Admin — adjust routing/permissions accordingly
- **Date/Time**: Ensure timezone handling matches backend (backend uses UTC)

---

## 🔗 API Endpoints Reference

Based on your backend controllers:

### Auth
- `POST /api/auth/login` - Login
- `POST /api/auth/register` - Register
- `POST /api/auth/logout` - Logout
- `POST /api/auth/refresh` - Refresh token

### User
- `POST /api/user/send-health-log?userHealthLogId={id}&doctorId={id}` - Send health log to doctor
- `GET /api/user/notifications` - Get notifications

### User Health Logs
- `GET /api/userhealthlog` - Get current user health logs
- `GET /api/userhealthlog/{id}` - Get health log by ID (Doctor only)
- `POST /api/userhealthlog` - Create health log
- `PUT /api/userhealthlog` - Update health log
- `DELETE /api/userhealthlog/{id}` - Delete health log

### Medicines
- `GET /api/medicine` - Get medicines (paginated)
- `GET /api/medicine/{id}` - Get medicine by ID
- `POST /api/medicine` - Create medicine (Doctor/Admin)
- `PUT /api/medicine` - Update medicine (Doctor/Admin)
- `DELETE /api/medicine/{id}` - Delete medicine (Doctor/Admin)

### Doctor
- `GET /api/doctor/medical-receipt` - Get medical receipts (paginated, filters)
- `POST /api/doctor/medical-receipt` - Create medical receipt
- `PUT /api/doctor/medical-receipt` - Update medical receipt
- `PUT /api/doctor/user-health-log-status/{id}` - Update health log status

### AI
- `GET /api/ai/diagnose` - Get diagnosis from symptoms
- `GET /api/ai/compare` - Compare medicines
- `GET /api/ai/summary-check/{period}` - Get health summary

---

**Good luck with your frontend development! 🚀**


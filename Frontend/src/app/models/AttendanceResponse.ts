import { Attendance } from './attendance';
export interface AttendanceResponse {
  $id: string;
  $values: Attendance[];
}
/*
------------------------------------------------------------------------------ 
This code was generated by Amplication. 
 
Changes to this file will be lost if the code is regenerated. 

There are other ways to to customize your code, see this doc to learn more
https://docs.amplication.com/how-to/custom-code

------------------------------------------------------------------------------
  */
import { InputType, Field } from "@nestjs/graphql";
import { ApiProperty } from "@nestjs/swagger";
import { StaffAgencyWhereUniqueInput } from "../../staffAgency/base/StaffAgencyWhereUniqueInput";
import { ValidateNested, IsOptional, IsEnum } from "class-validator";
import { Type } from "class-transformer";
import { StringFilter } from "../../util/StringFilter";
import { DateTimeNullableFilter } from "../../util/DateTimeNullableFilter";
import { FloatNullableFilter } from "../../util/FloatNullableFilter";
import { StaffWhereUniqueInput } from "../../staff/base/StaffWhereUniqueInput";
import { EnumPayrollStatus } from "./EnumPayrollStatus";

@InputType()
class PayrollWhereInput {
  @ApiProperty({
    required: false,
    type: () => StaffAgencyWhereUniqueInput,
  })
  @ValidateNested()
  @Type(() => StaffAgencyWhereUniqueInput)
  @IsOptional()
  @Field(() => StaffAgencyWhereUniqueInput, {
    nullable: true,
  })
  agency?: StaffAgencyWhereUniqueInput;

  @ApiProperty({
    required: false,
    type: StringFilter,
  })
  @Type(() => StringFilter)
  @IsOptional()
  @Field(() => StringFilter, {
    nullable: true,
  })
  id?: StringFilter;

  @ApiProperty({
    required: false,
    type: DateTimeNullableFilter,
  })
  @Type(() => DateTimeNullableFilter)
  @IsOptional()
  @Field(() => DateTimeNullableFilter, {
    nullable: true,
  })
  payDate?: DateTimeNullableFilter;

  @ApiProperty({
    required: false,
    type: FloatNullableFilter,
  })
  @Type(() => FloatNullableFilter)
  @IsOptional()
  @Field(() => FloatNullableFilter, {
    nullable: true,
  })
  salaryAmount?: FloatNullableFilter;

  @ApiProperty({
    required: false,
    type: () => StaffWhereUniqueInput,
  })
  @ValidateNested()
  @Type(() => StaffWhereUniqueInput)
  @IsOptional()
  @Field(() => StaffWhereUniqueInput, {
    nullable: true,
  })
  staff?: StaffWhereUniqueInput;

  @ApiProperty({
    required: false,
    enum: EnumPayrollStatus,
  })
  @IsEnum(EnumPayrollStatus)
  @IsOptional()
  @Field(() => EnumPayrollStatus, {
    nullable: true,
  })
  status?: "Option1";
}

export { PayrollWhereInput as PayrollWhereInput };

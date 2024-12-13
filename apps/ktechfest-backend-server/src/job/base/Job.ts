/*
------------------------------------------------------------------------------ 
This code was generated by Amplication. 
 
Changes to this file will be lost if the code is regenerated. 

There are other ways to to customize your code, see this doc to learn more
https://docs.amplication.com/how-to/custom-code

------------------------------------------------------------------------------
  */
import { ObjectType, Field } from "@nestjs/graphql";
import { ApiProperty } from "@nestjs/swagger";
import { Application } from "../../application/base/Application";

import {
  ValidateNested,
  IsOptional,
  IsBoolean,
  IsDate,
  IsString,
  MaxLength,
  IsNumber,
  Min,
  Max,
  IsEnum,
} from "class-validator";

import { Type } from "class-transformer";
import { User } from "../../user/base/User";
import { StaffAgency } from "../../staffAgency/base/StaffAgency";
import { IsJSONValue } from "../../validators";
import { GraphQLJSON } from "graphql-type-json";
import { JsonValue } from "type-fest";
import { Payment } from "../../payment/base/Payment";
import { Rating } from "../../rating/base/Rating";
import { Skill } from "../../skill/base/Skill";
import { EnumJobStatus } from "./EnumJobStatus";

@ObjectType()
class Job {
  @ApiProperty({
    required: false,
    type: () => [Application],
  })
  @ValidateNested()
  @Type(() => Application)
  @IsOptional()
  applications?: Array<Application>;

  @ApiProperty({
    required: false,
    type: () => User,
  })
  @ValidateNested()
  @Type(() => User)
  @IsOptional()
  assignedTo?: User | null;

  @ApiProperty({
    required: false,
    type: () => StaffAgency,
  })
  @ValidateNested()
  @Type(() => StaffAgency)
  @IsOptional()
  associatedAgency?: StaffAgency | null;

  @ApiProperty({
    required: false,
    type: Boolean,
  })
  @IsBoolean()
  @IsOptional()
  @Field(() => Boolean, {
    nullable: true,
  })
  availability!: boolean | null;

  @ApiProperty({
    required: false,
    type: Boolean,
  })
  @IsBoolean()
  @IsOptional()
  @Field(() => Boolean, {
    nullable: true,
  })
  completed!: boolean | null;

  @ApiProperty({
    required: true,
  })
  @IsDate()
  @Type(() => Date)
  @Field(() => Date)
  createdAt!: Date;

  @ApiProperty({
    required: false,
  })
  @IsJSONValue()
  @IsOptional()
  @Field(() => GraphQLJSON, {
    nullable: true,
  })
  cv!: JsonValue;

  @ApiProperty({
    required: true,
    type: String,
  })
  @IsString()
  @MaxLength(1000)
  @Field(() => String)
  description!: string;

  @ApiProperty({
    required: false,
    type: String,
  })
  @IsString()
  @MaxLength(1000)
  @IsOptional()
  @Field(() => String, {
    nullable: true,
  })
  duration!: string | null;

  @ApiProperty({
    required: true,
    type: String,
  })
  @IsString()
  @Field(() => String)
  id!: string;

  @ApiProperty({
    required: false,
    type: Boolean,
  })
  @IsBoolean()
  @IsOptional()
  @Field(() => Boolean, {
    nullable: true,
  })
  isAcceptedByAgency!: boolean | null;

  @ApiProperty({
    required: false,
    type: Boolean,
  })
  @IsBoolean()
  @IsOptional()
  @Field(() => Boolean, {
    nullable: true,
  })
  isPaid!: boolean | null;

  @ApiProperty({
    required: true,
    type: Number,
  })
  @IsNumber()
  @Min(-999999999)
  @Max(999999999)
  @Field(() => Number)
  payRate!: number;

  @ApiProperty({
    required: false,
    type: () => Payment,
  })
  @ValidateNested()
  @Type(() => Payment)
  @IsOptional()
  payments?: Payment | null;

  @ApiProperty({
    required: false,
    type: () => [Rating],
  })
  @ValidateNested()
  @Type(() => Rating)
  @IsOptional()
  ratings?: Array<Rating>;

  @ApiProperty({
    required: false,
    type: () => [Skill],
  })
  @ValidateNested()
  @Type(() => Skill)
  @IsOptional()
  requiredSkills?: Array<Skill>;

  @ApiProperty({
    required: false,
    enum: EnumJobStatus,
  })
  @IsEnum(EnumJobStatus)
  @IsOptional()
  @Field(() => EnumJobStatus, {
    nullable: true,
  })
  status?: "Pending" | "Assigned" | null;

  @ApiProperty({
    required: true,
    type: String,
  })
  @IsString()
  @MaxLength(1000)
  @Field(() => String)
  title!: string;

  @ApiProperty({
    required: true,
  })
  @IsDate()
  @Type(() => Date)
  @Field(() => Date)
  updatedAt!: Date;

  @ApiProperty({
    required: false,
    type: () => User,
  })
  @ValidateNested()
  @Type(() => User)
  @IsOptional()
  user?: User | null;
}

export { Job as Job };

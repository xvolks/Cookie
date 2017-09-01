package com.ankamagames.dofus.network.types.game.context.roleplay.job
{
   import com.ankamagames.dofus.network.ProtocolTypeManager;
   import com.ankamagames.dofus.network.types.game.interactive.skill.SkillActionDescription;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class JobDescription implements INetworkType
   {
      
      public static const protocolId:uint = 101;
       
      
      public var jobId:uint = 0;
      
      public var skills:Vector.<SkillActionDescription>;
      
      private var _skillstree:FuncTree;
      
      public function JobDescription()
      {
         this.skills = new Vector.<SkillActionDescription>();
         super();
      }
      
      public function getTypeId() : uint
      {
         return 101;
      }
      
      public function initJobDescription(param1:uint = 0, param2:Vector.<SkillActionDescription> = null) : JobDescription
      {
         this.jobId = param1;
         this.skills = param2;
         return this;
      }
      
      public function reset() : void
      {
         this.jobId = 0;
         this.skills = new Vector.<SkillActionDescription>();
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_JobDescription(param1);
      }
      
      public function serializeAs_JobDescription(param1:ICustomDataOutput) : void
      {
         if(this.jobId < 0)
         {
            throw new Error("Forbidden value (" + this.jobId + ") on element jobId.");
         }
         param1.writeByte(this.jobId);
         param1.writeShort(this.skills.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.skills.length)
         {
            param1.writeShort((this.skills[_loc2_] as SkillActionDescription).getTypeId());
            (this.skills[_loc2_] as SkillActionDescription).serialize(param1);
            _loc2_++;
         }
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_JobDescription(param1);
      }
      
      public function deserializeAs_JobDescription(param1:ICustomDataInput) : void
      {
         var _loc4_:uint = 0;
         var _loc5_:SkillActionDescription = null;
         this._jobIdFunc(param1);
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = param1.readUnsignedShort();
            _loc5_ = ProtocolTypeManager.getInstance(SkillActionDescription,_loc4_);
            _loc5_.deserialize(param1);
            this.skills.push(_loc5_);
            _loc3_++;
         }
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_JobDescription(param1);
      }
      
      public function deserializeAsyncAs_JobDescription(param1:FuncTree) : void
      {
         param1.addChild(this._jobIdFunc);
         this._skillstree = param1.addChild(this._skillstreeFunc);
      }
      
      private function _jobIdFunc(param1:ICustomDataInput) : void
      {
         this.jobId = param1.readByte();
         if(this.jobId < 0)
         {
            throw new Error("Forbidden value (" + this.jobId + ") on element of JobDescription.jobId.");
         }
      }
      
      private function _skillstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._skillstree.addChild(this._skillsFunc);
            _loc3_++;
         }
      }
      
      private function _skillsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:SkillActionDescription = ProtocolTypeManager.getInstance(SkillActionDescription,_loc2_);
         _loc3_.deserialize(param1);
         this.skills.push(_loc3_);
      }
   }
}

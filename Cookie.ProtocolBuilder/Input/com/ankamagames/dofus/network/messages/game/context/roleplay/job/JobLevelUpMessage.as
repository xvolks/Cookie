package com.ankamagames.dofus.network.messages.game.context.roleplay.job
{
   import com.ankamagames.dofus.network.types.game.context.roleplay.job.JobDescription;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class JobLevelUpMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5656;
       
      
      private var _isInitialized:Boolean = false;
      
      public var newLevel:uint = 0;
      
      public var jobsDescription:JobDescription;
      
      private var _jobsDescriptiontree:FuncTree;
      
      public function JobLevelUpMessage()
      {
         this.jobsDescription = new JobDescription();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5656;
      }
      
      public function initJobLevelUpMessage(param1:uint = 0, param2:JobDescription = null) : JobLevelUpMessage
      {
         this.newLevel = param1;
         this.jobsDescription = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.newLevel = 0;
         this.jobsDescription = new JobDescription();
         this._isInitialized = false;
      }
      
      override public function pack(param1:ICustomDataOutput) : void
      {
         var _loc2_:ByteArray = new ByteArray();
         this.serialize(new CustomDataWrapper(_loc2_));
         writePacket(param1,this.getMessageId(),_loc2_);
      }
      
      override public function unpack(param1:ICustomDataInput, param2:uint) : void
      {
         this.deserialize(param1);
      }
      
      override public function unpackAsync(param1:ICustomDataInput, param2:uint) : FuncTree
      {
         var _loc3_:FuncTree = new FuncTree();
         _loc3_.setRoot(param1);
         this.deserializeAsync(_loc3_);
         return _loc3_;
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_JobLevelUpMessage(param1);
      }
      
      public function serializeAs_JobLevelUpMessage(param1:ICustomDataOutput) : void
      {
         if(this.newLevel < 0 || this.newLevel > 255)
         {
            throw new Error("Forbidden value (" + this.newLevel + ") on element newLevel.");
         }
         param1.writeByte(this.newLevel);
         this.jobsDescription.serializeAs_JobDescription(param1);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_JobLevelUpMessage(param1);
      }
      
      public function deserializeAs_JobLevelUpMessage(param1:ICustomDataInput) : void
      {
         this._newLevelFunc(param1);
         this.jobsDescription = new JobDescription();
         this.jobsDescription.deserialize(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_JobLevelUpMessage(param1);
      }
      
      public function deserializeAsyncAs_JobLevelUpMessage(param1:FuncTree) : void
      {
         param1.addChild(this._newLevelFunc);
         this._jobsDescriptiontree = param1.addChild(this._jobsDescriptiontreeFunc);
      }
      
      private function _newLevelFunc(param1:ICustomDataInput) : void
      {
         this.newLevel = param1.readUnsignedByte();
         if(this.newLevel < 0 || this.newLevel > 255)
         {
            throw new Error("Forbidden value (" + this.newLevel + ") on element of JobLevelUpMessage.newLevel.");
         }
      }
      
      private function _jobsDescriptiontreeFunc(param1:ICustomDataInput) : void
      {
         this.jobsDescription = new JobDescription();
         this.jobsDescription.deserializeAsync(this._jobsDescriptiontree);
      }
   }
}

package com.ankamagames.dofus.network.messages.game.context.roleplay.job
{
   import com.ankamagames.dofus.network.types.game.context.roleplay.job.JobExperience;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class JobExperienceMultiUpdateMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5809;
       
      
      private var _isInitialized:Boolean = false;
      
      public var experiencesUpdate:Vector.<JobExperience>;
      
      private var _experiencesUpdatetree:FuncTree;
      
      public function JobExperienceMultiUpdateMessage()
      {
         this.experiencesUpdate = new Vector.<JobExperience>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5809;
      }
      
      public function initJobExperienceMultiUpdateMessage(param1:Vector.<JobExperience> = null) : JobExperienceMultiUpdateMessage
      {
         this.experiencesUpdate = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.experiencesUpdate = new Vector.<JobExperience>();
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
         this.serializeAs_JobExperienceMultiUpdateMessage(param1);
      }
      
      public function serializeAs_JobExperienceMultiUpdateMessage(param1:ICustomDataOutput) : void
      {
         param1.writeShort(this.experiencesUpdate.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.experiencesUpdate.length)
         {
            (this.experiencesUpdate[_loc2_] as JobExperience).serializeAs_JobExperience(param1);
            _loc2_++;
         }
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_JobExperienceMultiUpdateMessage(param1);
      }
      
      public function deserializeAs_JobExperienceMultiUpdateMessage(param1:ICustomDataInput) : void
      {
         var _loc4_:JobExperience = null;
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = new JobExperience();
            _loc4_.deserialize(param1);
            this.experiencesUpdate.push(_loc4_);
            _loc3_++;
         }
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_JobExperienceMultiUpdateMessage(param1);
      }
      
      public function deserializeAsyncAs_JobExperienceMultiUpdateMessage(param1:FuncTree) : void
      {
         this._experiencesUpdatetree = param1.addChild(this._experiencesUpdatetreeFunc);
      }
      
      private function _experiencesUpdatetreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._experiencesUpdatetree.addChild(this._experiencesUpdateFunc);
            _loc3_++;
         }
      }
      
      private function _experiencesUpdateFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:JobExperience = new JobExperience();
         _loc2_.deserialize(param1);
         this.experiencesUpdate.push(_loc2_);
      }
   }
}

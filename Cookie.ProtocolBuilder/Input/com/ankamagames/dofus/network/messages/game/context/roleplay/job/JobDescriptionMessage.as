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
   public class JobDescriptionMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5655;
       
      
      private var _isInitialized:Boolean = false;
      
      public var jobsDescription:Vector.<JobDescription>;
      
      private var _jobsDescriptiontree:FuncTree;
      
      public function JobDescriptionMessage()
      {
         this.jobsDescription = new Vector.<JobDescription>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5655;
      }
      
      public function initJobDescriptionMessage(param1:Vector.<JobDescription> = null) : JobDescriptionMessage
      {
         this.jobsDescription = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.jobsDescription = new Vector.<JobDescription>();
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
         this.serializeAs_JobDescriptionMessage(param1);
      }
      
      public function serializeAs_JobDescriptionMessage(param1:ICustomDataOutput) : void
      {
         param1.writeShort(this.jobsDescription.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.jobsDescription.length)
         {
            (this.jobsDescription[_loc2_] as JobDescription).serializeAs_JobDescription(param1);
            _loc2_++;
         }
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_JobDescriptionMessage(param1);
      }
      
      public function deserializeAs_JobDescriptionMessage(param1:ICustomDataInput) : void
      {
         var _loc4_:JobDescription = null;
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = new JobDescription();
            _loc4_.deserialize(param1);
            this.jobsDescription.push(_loc4_);
            _loc3_++;
         }
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_JobDescriptionMessage(param1);
      }
      
      public function deserializeAsyncAs_JobDescriptionMessage(param1:FuncTree) : void
      {
         this._jobsDescriptiontree = param1.addChild(this._jobsDescriptiontreeFunc);
      }
      
      private function _jobsDescriptiontreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._jobsDescriptiontree.addChild(this._jobsDescriptionFunc);
            _loc3_++;
         }
      }
      
      private function _jobsDescriptionFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:JobDescription = new JobDescription();
         _loc2_.deserialize(param1);
         this.jobsDescription.push(_loc2_);
      }
   }
}

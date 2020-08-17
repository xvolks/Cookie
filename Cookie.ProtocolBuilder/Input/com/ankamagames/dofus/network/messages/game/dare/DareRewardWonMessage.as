package com.ankamagames.dofus.network.messages.game.dare
{
   import com.ankamagames.dofus.network.types.game.dare.DareReward;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class DareRewardWonMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6678;
       
      
      private var _isInitialized:Boolean = false;
      
      public var reward:DareReward;
      
      private var _rewardtree:FuncTree;
      
      public function DareRewardWonMessage()
      {
         this.reward = new DareReward();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6678;
      }
      
      public function initDareRewardWonMessage(param1:DareReward = null) : DareRewardWonMessage
      {
         this.reward = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.reward = new DareReward();
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
         this.serializeAs_DareRewardWonMessage(param1);
      }
      
      public function serializeAs_DareRewardWonMessage(param1:ICustomDataOutput) : void
      {
         this.reward.serializeAs_DareReward(param1);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_DareRewardWonMessage(param1);
      }
      
      public function deserializeAs_DareRewardWonMessage(param1:ICustomDataInput) : void
      {
         this.reward = new DareReward();
         this.reward.deserialize(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_DareRewardWonMessage(param1);
      }
      
      public function deserializeAsyncAs_DareRewardWonMessage(param1:FuncTree) : void
      {
         this._rewardtree = param1.addChild(this._rewardtreeFunc);
      }
      
      private function _rewardtreeFunc(param1:ICustomDataInput) : void
      {
         this.reward = new DareReward();
         this.reward.deserializeAsync(this._rewardtree);
      }
   }
}

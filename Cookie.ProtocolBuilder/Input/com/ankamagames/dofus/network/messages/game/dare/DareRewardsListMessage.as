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
   public class DareRewardsListMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6677;
       
      
      private var _isInitialized:Boolean = false;
      
      public var rewards:Vector.<DareReward>;
      
      private var _rewardstree:FuncTree;
      
      public function DareRewardsListMessage()
      {
         this.rewards = new Vector.<DareReward>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6677;
      }
      
      public function initDareRewardsListMessage(param1:Vector.<DareReward> = null) : DareRewardsListMessage
      {
         this.rewards = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.rewards = new Vector.<DareReward>();
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
         this.serializeAs_DareRewardsListMessage(param1);
      }
      
      public function serializeAs_DareRewardsListMessage(param1:ICustomDataOutput) : void
      {
         param1.writeShort(this.rewards.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.rewards.length)
         {
            (this.rewards[_loc2_] as DareReward).serializeAs_DareReward(param1);
            _loc2_++;
         }
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_DareRewardsListMessage(param1);
      }
      
      public function deserializeAs_DareRewardsListMessage(param1:ICustomDataInput) : void
      {
         var _loc4_:DareReward = null;
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = new DareReward();
            _loc4_.deserialize(param1);
            this.rewards.push(_loc4_);
            _loc3_++;
         }
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_DareRewardsListMessage(param1);
      }
      
      public function deserializeAsyncAs_DareRewardsListMessage(param1:FuncTree) : void
      {
         this._rewardstree = param1.addChild(this._rewardstreeFunc);
      }
      
      private function _rewardstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._rewardstree.addChild(this._rewardsFunc);
            _loc3_++;
         }
      }
      
      private function _rewardsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:DareReward = new DareReward();
         _loc2_.deserialize(param1);
         this.rewards.push(_loc2_);
      }
   }
}

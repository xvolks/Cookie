package com.ankamagames.dofus.network.messages.game.actions.fight
{
   import com.ankamagames.dofus.network.messages.game.actions.AbstractGameActionMessage;
   import com.ankamagames.dofus.network.types.game.actions.fight.GameActionMark;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class GameActionFightMarkCellsMessage extends AbstractGameActionMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5540;
       
      
      private var _isInitialized:Boolean = false;
      
      public var mark:GameActionMark;
      
      private var _marktree:FuncTree;
      
      public function GameActionFightMarkCellsMessage()
      {
         this.mark = new GameActionMark();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return super.isInitialized && this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5540;
      }
      
      public function initGameActionFightMarkCellsMessage(param1:uint = 0, param2:Number = 0, param3:GameActionMark = null) : GameActionFightMarkCellsMessage
      {
         super.initAbstractGameActionMessage(param1,param2);
         this.mark = param3;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.mark = new GameActionMark();
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
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_GameActionFightMarkCellsMessage(param1);
      }
      
      public function serializeAs_GameActionFightMarkCellsMessage(param1:ICustomDataOutput) : void
      {
         super.serializeAs_AbstractGameActionMessage(param1);
         this.mark.serializeAs_GameActionMark(param1);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameActionFightMarkCellsMessage(param1);
      }
      
      public function deserializeAs_GameActionFightMarkCellsMessage(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this.mark = new GameActionMark();
         this.mark.deserialize(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameActionFightMarkCellsMessage(param1);
      }
      
      public function deserializeAsyncAs_GameActionFightMarkCellsMessage(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         this._marktree = param1.addChild(this._marktreeFunc);
      }
      
      private function _marktreeFunc(param1:ICustomDataInput) : void
      {
         this.mark = new GameActionMark();
         this.mark.deserializeAsync(this._marktree);
      }
   }
}

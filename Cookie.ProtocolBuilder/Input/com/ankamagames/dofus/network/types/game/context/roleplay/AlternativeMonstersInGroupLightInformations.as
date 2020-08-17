package com.ankamagames.dofus.network.types.game.context.roleplay
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class AlternativeMonstersInGroupLightInformations implements INetworkType
   {
      
      public static const protocolId:uint = 394;
       
      
      public var playerCount:int = 0;
      
      public var monsters:Vector.<MonsterInGroupLightInformations>;
      
      private var _monsterstree:FuncTree;
      
      public function AlternativeMonstersInGroupLightInformations()
      {
         this.monsters = new Vector.<MonsterInGroupLightInformations>();
         super();
      }
      
      public function getTypeId() : uint
      {
         return 394;
      }
      
      public function initAlternativeMonstersInGroupLightInformations(param1:int = 0, param2:Vector.<MonsterInGroupLightInformations> = null) : AlternativeMonstersInGroupLightInformations
      {
         this.playerCount = param1;
         this.monsters = param2;
         return this;
      }
      
      public function reset() : void
      {
         this.playerCount = 0;
         this.monsters = new Vector.<MonsterInGroupLightInformations>();
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_AlternativeMonstersInGroupLightInformations(param1);
      }
      
      public function serializeAs_AlternativeMonstersInGroupLightInformations(param1:ICustomDataOutput) : void
      {
         param1.writeInt(this.playerCount);
         param1.writeShort(this.monsters.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.monsters.length)
         {
            (this.monsters[_loc2_] as MonsterInGroupLightInformations).serializeAs_MonsterInGroupLightInformations(param1);
            _loc2_++;
         }
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_AlternativeMonstersInGroupLightInformations(param1);
      }
      
      public function deserializeAs_AlternativeMonstersInGroupLightInformations(param1:ICustomDataInput) : void
      {
         var _loc4_:MonsterInGroupLightInformations = null;
         this._playerCountFunc(param1);
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = new MonsterInGroupLightInformations();
            _loc4_.deserialize(param1);
            this.monsters.push(_loc4_);
            _loc3_++;
         }
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_AlternativeMonstersInGroupLightInformations(param1);
      }
      
      public function deserializeAsyncAs_AlternativeMonstersInGroupLightInformations(param1:FuncTree) : void
      {
         param1.addChild(this._playerCountFunc);
         this._monsterstree = param1.addChild(this._monsterstreeFunc);
      }
      
      private function _playerCountFunc(param1:ICustomDataInput) : void
      {
         this.playerCount = param1.readInt();
      }
      
      private function _monsterstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._monsterstree.addChild(this._monstersFunc);
            _loc3_++;
         }
      }
      
      private function _monstersFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:MonsterInGroupLightInformations = new MonsterInGroupLightInformations();
         _loc2_.deserialize(param1);
         this.monsters.push(_loc2_);
      }
   }
}
